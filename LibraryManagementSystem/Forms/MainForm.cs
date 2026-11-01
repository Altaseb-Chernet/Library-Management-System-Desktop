using LibraryManagementSystem.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private readonly LibraryService libraryService;
        private readonly string userRole;

        public MainForm() : this(new LibraryService(), "Administrator")
        {
        }

        public MainForm(LibraryService service, string role)
        {
            libraryService = service;
            userRole = role;
            InitializeComponent();
            headerLabel.Text = $"Library Management System   |   {userRole}";
            tabs.SelectedIndexChanged += (_, _) => ShowPage((Form)tabs.SelectedTab!.Tag!);
            AddPage("Home", new HomeForm(libraryService));
            AddPage("Books", new BooksForm(libraryService));
            AddPage("Members", new MembersForm(libraryService));
            AddPage("Issue / Return", new IssueReturnForm(libraryService));
            if (userRole == "Administrator")
                AddPage("Staff", new StaffForm(libraryService));
            AddPage("Reports", new ReportsForm(libraryService));

            if (tabs.TabPages.Count > 0)
                ShowPage((Form)tabs.TabPages[0].Tag!);
        }

        private void AddPage(string title, Form page)
        {
            var tab = new TabPage(title) { Tag = page, BackColor = Color.White };
            tabs.TabPages.Add(tab);
        }

        private void ShowPage(Form page)
        {
            pageGroup.Controls.Clear();
            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;
            pageGroup.Controls.Add(page);
            page.Show();
        }
    }
}
