using LibraryApp.Services;

namespace LibraryApp.Forms;

public class LoginForm : Form
{
    private readonly TextBox txtUser = new() { Location = new Point(40, 140), Width = 280 };
    private readonly TextBox txtPass = new() { Location = new Point(40, 200), Width = 280, UseSystemPasswordChar = true };
    private readonly Label lblError = new()
    {
        Location = new Point(40, 235), Size = new Size(280, 20), ForeColor = Ui.Danger, Text = ""
    };
    private readonly Button btnLogin = Ui.MakeButton("Login", 40, 262, 135, primary: true);
    private readonly Button btnCancel = Ui.MakeButton("Cancel", 185, 262, 135);
    private int attempts;

    public LoginForm()
    {
        Text = "Library Management System - Login";
        ClientSize = new Size(360, 330);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Font = new Font("Segoe UI", 9.5f);
        BackColor = Color.White;

        var header = new Panel { Dock = DockStyle.Top, Height = 100, BackColor = Ui.Primary };
        header.Controls.Add(new Label
        {
            Text = "Library Management System",
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 15f, FontStyle.Bold),
            AutoSize = true,
            Location = new Point(40, 22)
        });
        header.Controls.Add(new Label
        {
            Text = "Please sign in to continue",
            ForeColor = Color.FromArgb(200, 215, 230),
            AutoSize = true,
            Location = new Point(42, 58)
        });

        Controls.Add(header);
        Controls.Add(Ui.MakeLabel("Username", 40, 118));
        Controls.Add(txtUser);
        Controls.Add(Ui.MakeLabel("Password", 40, 178));
        Controls.Add(txtPass);
        Controls.Add(lblError);
        Controls.Add(btnLogin);
        Controls.Add(btnCancel);

        AcceptButton = btnLogin;   // Enter key = Login
        CancelButton = btnCancel;  // Esc key = Cancel

        btnLogin.Click += (_, _) => DoLogin();
        btnCancel.Click += (_, _) => DialogResult = DialogResult.Cancel;
        txtUser.TextChanged += (_, _) => lblError.Text = "";
        txtPass.TextChanged += (_, _) => lblError.Text = "";
    }

    private void DoLogin()
    {
        if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
        {
            lblError.Text = "Enter your username and password.";
            return;
        }

        var result = LibraryService.Login(txtUser.Text, txtPass.Text);
        if (result.Ok)
        {
            DialogResult = DialogResult.OK;
            return;
        }

        attempts++;
        lblError.Text = result.Message;
        txtPass.Clear();
        txtPass.Focus();
        if (attempts >= 3)
        {
            MessageBox.Show("Too many failed attempts. The application will close.",
                "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            DialogResult = DialogResult.Cancel;
        }
    }
}
