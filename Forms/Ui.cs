namespace LibraryApp.Forms;

/// <summary>Small helpers so every screen has the same clean look.</summary>
public static class Ui
{
    public static readonly Color Primary = Color.FromArgb(31, 78, 121);
    public static readonly Color PrimaryDark = Color.FromArgb(22, 58, 92);
    public static readonly Color Panel = Color.FromArgb(242, 246, 250);
    public static readonly Color Danger = Color.FromArgb(192, 57, 43);
    public static readonly Color Success = Color.FromArgb(39, 130, 80);

    public static Label MakeLabel(string text, int x, int y, bool bold = false) => new()
    {
        Text = text,
        Location = new Point(x, y),
        AutoSize = true,
        ForeColor = Color.FromArgb(60, 60, 60),
        Font = bold ? new Font("Segoe UI", 9.5f, FontStyle.Bold) : new Font("Segoe UI", 9.5f)
    };

    public static Button MakeButton(string text, int x, int y, int width = 90, bool primary = false)
    {
        var b = new Button
        {
            Text = text,
            Location = new Point(x, y),
            Size = new Size(width, 32),
            FlatStyle = FlatStyle.Flat,
            Cursor = Cursors.Hand,
            BackColor = primary ? Primary : Color.White,
            ForeColor = primary ? Color.White : Primary,
            UseVisualStyleBackColor = false
        };
        b.FlatAppearance.BorderColor = Primary;
        return b;
    }

    public static ListView MakeList(params (string Name, int Width)[] columns)
    {
        var lv = new ListView
        {
            Dock = DockStyle.Fill,
            View = View.Details,
            FullRowSelect = true,
            GridLines = true,
            MultiSelect = false,
            HideSelection = false,
            BorderStyle = BorderStyle.FixedSingle
        };
        foreach (var (name, width) in columns)
            lv.Columns.Add(name, width);
        return lv;
    }

    public static int? SelectedId(ListView lv) =>
        lv.SelectedItems.Count > 0 ? (int?)lv.SelectedItems[0].Tag : null;

    public static ListViewItem Row(int id, params string[] cells) =>
        new ListViewItem(cells) { Tag = id };

    public static bool Confirm(string message) =>
        MessageBox.Show(message, "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    public static void Info(string message) =>
        MessageBox.Show(message, "Library Management System", MessageBoxButtons.OK, MessageBoxIcon.Information);
}

/// <summary>
/// Base class for every screen shown inside the main window.
/// It refreshes itself whenever the data changes (event-driven).
/// </summary>
public abstract class ChildForm : Form
{
    protected ChildForm()
    {
        Font = new Font("Segoe UI", 9.5f);
        BackColor = Color.White;
    }

    protected abstract void RefreshData();

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Services.LibraryService.DataChanged += RefreshData;
        RefreshData();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        Services.LibraryService.DataChanged -= RefreshData;
        base.OnFormClosed(e);
    }

    protected static void Report(Models.Result r) => MainForm.SetStatus(r.Message, !r.Ok);
}
