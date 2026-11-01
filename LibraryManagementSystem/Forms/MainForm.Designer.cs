namespace LibraryManagementSystem.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label headerLabel;
        private TabControl tabs;
        private GroupBox pageGroup;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerLabel = new Label();
            tabs = new TabControl();
            pageGroup = new GroupBox();
            SuspendLayout();
            headerLabel.BackColor = Color.FromArgb(38, 90, 130);
            headerLabel.Dock = DockStyle.Top;
            headerLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            headerLabel.ForeColor = Color.White;
            headerLabel.Height = 48;
            headerLabel.Padding = new Padding(18, 12, 0, 0);
            headerLabel.Text = "Library Management System";
            tabs.Dock = DockStyle.Top;
            tabs.Font = new Font("Segoe UI", 10F);
            tabs.Height = 42;
            tabs.Alignment = TabAlignment.Top;
            tabs.Multiline = false;
            tabs.SizeMode = TabSizeMode.Normal;
            tabs.Padding = new Point(14, 5);
            pageGroup.Dock = DockStyle.Fill;
            pageGroup.Padding = new Padding(10);
            pageGroup.Text = "Workspace";
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1000, 650);
            Controls.Add(pageGroup);
            Controls.Add(tabs);
            Controls.Add(headerLabel);
            MinimumSize = new Size(850, 560);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Library Management System";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }
    }
}