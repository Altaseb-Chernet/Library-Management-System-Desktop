namespace LibraryManagementSystem.Forms
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel contentLayout;
        private Label titleLabel;
        private Label descriptionLabel;
        private GroupBox summaryGroup;
        private TableLayoutPanel summaryTable;
        private Label booksSummaryLabel;
        private Label membersSummaryLabel;
        private Label loansSummaryLabel;

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
            contentLayout = new TableLayoutPanel();
            titleLabel = new Label();
            descriptionLabel = new Label();
            summaryGroup = new GroupBox();
            summaryTable = new TableLayoutPanel();
            booksSummaryLabel = new Label();
            membersSummaryLabel = new Label();
            loansSummaryLabel = new Label();
            contentLayout.SuspendLayout();
            summaryGroup.SuspendLayout();
            summaryTable.SuspendLayout();
            SuspendLayout();
            contentLayout.AutoScroll = true;
            contentLayout.ColumnCount = 1;
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentLayout.Dock = DockStyle.Fill;
            contentLayout.Padding = new Padding(30);
            contentLayout.RowCount = 3;
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 55F));
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            contentLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            contentLayout.Controls.Add(titleLabel, 0, 0);
            contentLayout.Controls.Add(descriptionLabel, 0, 1);
            contentLayout.Controls.Add(summaryGroup, 0, 2);
            titleLabel.Dock = DockStyle.Fill;
            titleLabel.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            titleLabel.Text = "Welcome to the library";
            titleLabel.TextAlign = ContentAlignment.MiddleLeft;
            descriptionLabel.Dock = DockStyle.Fill;
            descriptionLabel.ForeColor = Color.DimGray;
            descriptionLabel.Text = "Use the tabs above to manage books, members, and lending.\r\nThis sample keeps all data in memory while the application is open.";
            descriptionLabel.TextAlign = ContentAlignment.MiddleLeft;
            summaryGroup.Controls.Add(summaryTable);
            summaryGroup.Dock = DockStyle.Fill;
            summaryGroup.MinimumSize = new Size(420, 125);
            summaryGroup.Padding = new Padding(12);
            summaryGroup.Text = "Today at a glance";
            summaryTable.ColumnCount = 3;
            summaryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333F));
            summaryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333F));
            summaryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.333F));
            summaryTable.Dock = DockStyle.Fill;
            summaryTable.RowCount = 1;
            summaryTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            summaryTable.Controls.Add(booksSummaryLabel, 0, 0);
            summaryTable.Controls.Add(membersSummaryLabel, 1, 0);
            summaryTable.Controls.Add(loansSummaryLabel, 2, 0);
            booksSummaryLabel.AutoSize = false;
            booksSummaryLabel.Dock = DockStyle.Fill;
            booksSummaryLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            booksSummaryLabel.Text = "Books\r\n0";
            booksSummaryLabel.TextAlign = ContentAlignment.MiddleCenter;
            membersSummaryLabel.AutoSize = false;
            membersSummaryLabel.Dock = DockStyle.Fill;
            membersSummaryLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            membersSummaryLabel.Text = "Members\r\n0";
            membersSummaryLabel.TextAlign = ContentAlignment.MiddleCenter;
            loansSummaryLabel.AutoSize = false;
            loansSummaryLabel.Dock = DockStyle.Fill;
            loansSummaryLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            loansSummaryLabel.Text = "On loan\r\n0";
            loansSummaryLabel.TextAlign = ContentAlignment.MiddleCenter;
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(contentLayout);
            Name = "HomeForm";
            Text = "Home";
            summaryTable.ResumeLayout(false);
            summaryGroup.ResumeLayout(false);
            contentLayout.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
    }
}