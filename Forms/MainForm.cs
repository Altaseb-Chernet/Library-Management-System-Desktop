using LibraryApp.Services;

namespace LibraryApp.Forms;

/// <summary>Main window: menu bar, toolbar, status bar and a content area for each screen.</summary>
public class MainForm : Form
{
    private static MainForm? current;

    private readonly MenuStrip menu = new();
    private readonly ToolStrip toolbar = new();
    private readonly StatusStrip status = new();
    private readonly ToolStripStatusLabel lblMessage = new() { Spring = true, TextAlign = ContentAlignment.MiddleLeft };
    private readonly ToolStripStatusLabel lblUser = new();
    private readonly ToolStripStatusLabel lblClock = new();
    private readonly Panel host = new() { Dock = DockStyle.Fill, BackColor = Color.White };
    private readonly System.Windows.Forms.Timer clock = new() { Interval = 1000 };
    private Form? shown;

    public bool LoggedOut { get; private set; }

    public MainForm()
    {
        current = this;
        Text = "Library Management System";
        Size = new Size(1100, 700);
        MinimumSize = new Size(900, 600);
        StartPosition = FormStartPosition.CenterScreen;
        Font = new Font("Segoe UI", 9.5f);

        BuildMenu();
        BuildToolbar();
        BuildStatusBar();

        // Fill first, then the bars (WinForms docks the last-added control first)
        Controls.Add(host);
        Controls.Add(toolbar);
        Controls.Add(menu);
        Controls.Add(status);
        MainMenuStrip = menu;

        clock.Tick += (_, _) => lblClock.Text = DateTime.Now.ToString("ddd dd MMM yyyy  HH:mm:ss");
        clock.Start();

        Load += (_, _) =>
        {
            var u = LibraryService.CurrentUser;
            lblUser.Text = u == null ? "" : $"{u.FullName} ({u.Role})";
            Navigate("Home");
            SetStatus("Ready.");
        };

        FormClosing += OnFormClosing;
        FormClosed += (_, _) =>
        {
            clock.Stop();
            clock.Dispose();
            shown?.Close();   // unsubscribes the open screen from data events
            if (current == this) current = null;
        };
    }

    // ---- Public helpers used by other screens -----------------------------
    public static void SetStatus(string message, bool isError = false)
    {
        if (current == null) return;
        current.lblMessage.Text = message;
        current.lblMessage.ForeColor = isError ? Ui.Danger : Ui.Success;
    }

    public static void GoTo(string screen) => current?.Navigate(screen);

    // ---- Navigation -------------------------------------------------------
    private void Navigate(string screen)
    {
        ChildForm next = screen switch
        {
            "Books"   => new BooksForm(),
            "Members" => new MembersForm(),
            "Loans"   => new IssueReturnForm(),
            "Reports" => new ReportsForm(),
            _         => new HomeForm()
        };

        shown?.Close();
        shown = next;
        next.TopLevel = false;
        next.FormBorderStyle = FormBorderStyle.None;
        next.Dock = DockStyle.Fill;
        host.Controls.Add(next);
        next.Show();
        SetStatus(screen == "Home" ? "Ready." : $"{screen} screen opened.");
    }

    // ---- Menu / toolbar / status bar --------------------------------------
    private void BuildMenu()
    {
        var file = new ToolStripMenuItem("&File");
        file.DropDownItems.Add(Item("Home", Keys.Control | Keys.H, () => Navigate("Home")));
        file.DropDownItems.Add(new ToolStripSeparator());
        file.DropDownItems.Add(Item("Logout", Keys.Control | Keys.L, Logout));
        file.DropDownItems.Add(Item("Exit", Keys.Control | Keys.Q, Close));

        var manage = new ToolStripMenuItem("&Manage");
        manage.DropDownItems.Add(Item("Books", Keys.Control | Keys.B, () => Navigate("Books")));
        manage.DropDownItems.Add(Item("Members", Keys.Control | Keys.M, () => Navigate("Members")));

        var loans = new ToolStripMenuItem("&Loans");
        loans.DropDownItems.Add(Item("Issue / Return", Keys.Control | Keys.I, () => Navigate("Loans")));

        var reports = new ToolStripMenuItem("&Reports");
        reports.DropDownItems.Add(Item("View reports", Keys.Control | Keys.R, () => Navigate("Reports")));

        var help = new ToolStripMenuItem("&Help");
        help.DropDownItems.Add(Item("About", Keys.F1, () => Ui.Info(
            "Library Management System\nPhase 1 - Desktop Application (WinForms)\n\n" +
            "Data is stored in memory only and is lost when the program closes.")));

        menu.Items.AddRange(new ToolStripItem[] { file, manage, loans, reports, help });
    }

    private void BuildToolbar()
    {
        toolbar.GripStyle = ToolStripGripStyle.Hidden;
        toolbar.Padding = new Padding(8, 4, 8, 4);
        toolbar.BackColor = Ui.Panel;
        toolbar.Items.Add(ToolButton("Home", () => Navigate("Home")));
        toolbar.Items.Add(ToolButton("Books", () => Navigate("Books")));
        toolbar.Items.Add(ToolButton("Members", () => Navigate("Members")));
        toolbar.Items.Add(ToolButton("Issue / Return", () => Navigate("Loans")));
        toolbar.Items.Add(ToolButton("Reports", () => Navigate("Reports")));
    }

    private void BuildStatusBar()
    {
        lblUser.BorderSides = ToolStripStatusLabelBorderSides.Left;
        lblClock.BorderSides = ToolStripStatusLabelBorderSides.Left;
        status.Items.AddRange(new ToolStripItem[] { lblMessage, lblUser, lblClock });
    }

    private static ToolStripMenuItem Item(string text, Keys shortcut, Action action)
    {
        var item = new ToolStripMenuItem(text) { ShortcutKeys = shortcut };
        item.Click += (_, _) => action();
        return item;
    }

    private static ToolStripButton ToolButton(string text, Action action)
    {
        var b = new ToolStripButton(text) { DisplayStyle = ToolStripItemDisplayStyle.Text, Padding = new Padding(8, 2, 8, 2) };
        b.Click += (_, _) => action();
        return b;
    }

    // ---- Logout / exit ----------------------------------------------------
    private void Logout()
    {
        if (!Ui.Confirm("Do you want to log out?")) return;
        LoggedOut = true;
        LibraryService.Logout();
        Close();
    }

    private void OnFormClosing(object? sender, FormClosingEventArgs e)
    {
        if (LoggedOut) return;
        if (!Ui.Confirm("Exit the application? Data stored in memory will be lost."))
            e.Cancel = true;
    }
}
