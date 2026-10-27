using LibraryApp.Forms;

namespace LibraryApp;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Login -> main window. After "Logout" the login form is shown again.
        while (true)
        {
            using (var login = new LoginForm())
            {
                if (login.ShowDialog() != DialogResult.OK)
                    break;
            }

            var main = new MainForm();
            Application.Run(main);
            if (!main.LoggedOut)
                break;
        }
    }
}
