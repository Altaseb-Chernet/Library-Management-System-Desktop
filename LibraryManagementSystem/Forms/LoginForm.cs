using LibraryManagementSystem.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private readonly LibraryService libraryService;

        public string UserRole { get; private set; } = string.Empty;

        public LoginForm() : this(new LibraryService())
        {
        }

        public LoginForm(LibraryService service)
        {
            libraryService = service;
            InitializeComponent();
        }

        private void SignInButton_Click(object? sender, EventArgs e)
        {
            var staff = libraryService.ValidateLogin(usernameTextBox.Text.Trim(), passwordTextBox.Text);
            if (staff is null)
            {
                messageLabel.Text = "The username or password is not correct.";
                messageLabel.ForeColor = Color.Firebrick;
                return;
            }

            UserRole = staff.Role;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
