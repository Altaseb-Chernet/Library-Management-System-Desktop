using LibraryManagementSystem.Forms;
using LibraryManagementSystem.Services;

namespace LibraryManagementSystem
{
    public partial class Form1 : Form
    {
        private readonly LibraryService libraryService = new();

        public Form1()
        {
            InitializeComponent();
            Shown += StartApplication;
        }

        private void StartApplication(object? sender, EventArgs e)
        {
            Hide();

            using var login = new LoginForm(libraryService);
            if (login.ShowDialog() != DialogResult.OK)
            {
                Close();
                return;
            }

            using var main = new MainForm(libraryService, login.UserRole);
            main.ShowDialog();
            Close();
        }
    }
}
