namespace LibraryManagementSystem.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Label titleLabel;
        private Label subtitleLabel;
        private GroupBox loginGroup;
        private Label usernameLabel;
        private Label passwordLabel;
        private TextBox usernameTextBox;
        private TextBox passwordTextBox;
        private Button signInButton;
        private Label messageLabel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            titleLabel = new Label();
            subtitleLabel = new Label();
            loginGroup = new GroupBox();
            usernameLabel = new Label();
            passwordLabel = new Label();
            usernameTextBox = new TextBox();
            passwordTextBox = new TextBox();
            signInButton = new Button();
            messageLabel = new Label();
            loginGroup.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 17F, FontStyle.Bold);
            titleLabel.Location = new Point(55, 35);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(297, 32);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Library Management System";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.ForeColor = Color.DimGray;
            subtitleLabel.Location = new Point(145, 75);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(121, 15);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Sign in to continue";
            // 
            // loginGroup
            // 
            loginGroup.Controls.Add(usernameLabel);
            loginGroup.Controls.Add(passwordLabel);
            loginGroup.Controls.Add(usernameTextBox);
            loginGroup.Controls.Add(passwordTextBox);
            loginGroup.Controls.Add(signInButton);
            loginGroup.Location = new Point(45, 110);
            loginGroup.Name = "loginGroup";
            loginGroup.Size = new Size(330, 150);
            loginGroup.TabIndex = 2;
            loginGroup.TabStop = false;
            loginGroup.Text = "Account";
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(20, 32);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(55, 15);
            usernameLabel.TabIndex = 3;
            usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(20, 70);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(55, 15);
            passwordLabel.TabIndex = 4;
            passwordLabel.Text = "Password";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Location = new Point(95, 28);
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.Size = new Size(205, 23);
            usernameTextBox.TabIndex = 5;
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(95, 66);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PasswordChar = '*';
            passwordTextBox.Size = new Size(205, 23);
            passwordTextBox.TabIndex = 6;
            // 
            // signInButton
            // 
            signInButton.BackColor = Color.FromArgb(38, 90, 130);
            signInButton.FlatStyle = FlatStyle.Flat;
            signInButton.ForeColor = Color.White;
            signInButton.Location = new Point(215, 105);
            signInButton.Name = "signInButton";
            signInButton.Size = new Size(85, 28);
            signInButton.TabIndex = 7;
            signInButton.Text = "Sign in";
            signInButton.UseVisualStyleBackColor = false;
            signInButton.Click += SignInButton_Click;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.ForeColor = Color.DimGray;
            messageLabel.Location = new Point(68, 280);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(286, 15);
            messageLabel.TabIndex = 3;
            messageLabel.Text = "Try admin / admin123 or librarian / library123";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(420, 330);
            Controls.Add(titleLabel);
            Controls.Add(subtitleLabel);
            Controls.Add(loginGroup);
            Controls.Add(messageLabel);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management System - Sign in";
            loginGroup.ResumeLayout(false);
            loginGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}