namespace LibraryManagementSystem.Forms
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.GroupBox reportGroup;
        private TableLayoutPanel summaryTable;
        private System.Windows.Forms.Label totalBooksLabel;
        private System.Windows.Forms.Label loansLabel;
        private System.Windows.Forms.Label membersLabel;
        private System.Windows.Forms.Label overdueLabel;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            titleLabel = new Label();
            reportGroup = new GroupBox();
            summaryTable = new TableLayoutPanel();
            totalBooksLabel = new Label();
            loansLabel = new Label();
            membersLabel = new Label();
            overdueLabel = new Label();
            reportGroup.SuspendLayout();
            summaryTable.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Margin = new Padding(4, 0, 4, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(151, 48);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Reports";
            // 
            // reportGroup
            // 
            reportGroup.Controls.Add(summaryTable);
            reportGroup.Dock = DockStyle.Fill;
            reportGroup.Location = new Point(0, 48);
            reportGroup.Margin = new Padding(4, 5, 4, 5);
            reportGroup.Name = "reportGroup";
            reportGroup.Padding = new Padding(12);
            reportGroup.Size = new Size(1000, 602);
            reportGroup.TabIndex = 1;
            reportGroup.TabStop = false;
            reportGroup.Text = "Library summary";
            // 
            // summaryTable
            // 
            summaryTable.ColumnCount = 4;
            summaryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            summaryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            summaryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            summaryTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            summaryTable.Controls.Add(totalBooksLabel, 0, 0);
            summaryTable.Controls.Add(loansLabel, 1, 0);
            summaryTable.Controls.Add(membersLabel, 2, 0);
            summaryTable.Controls.Add(overdueLabel, 3, 0);
            summaryTable.Dock = DockStyle.Fill;
            summaryTable.Location = new Point(12, 36);
            summaryTable.Name = "summaryTable";
            summaryTable.RowCount = 1;
            summaryTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            summaryTable.Size = new Size(976, 554);
            summaryTable.TabIndex = 0;
            // 
            // totalBooksLabel
            // 
            totalBooksLabel.Dock = DockStyle.Fill;
            totalBooksLabel.Location = new Point(3, 0);
            totalBooksLabel.Name = "totalBooksLabel";
            totalBooksLabel.Size = new Size(238, 554);
            totalBooksLabel.TabIndex = 0;
            totalBooksLabel.Text = "Total books: 24";
            totalBooksLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // loansLabel
            // 
            loansLabel.Dock = DockStyle.Fill;
            loansLabel.Location = new Point(247, 0);
            loansLabel.Name = "loansLabel";
            loansLabel.Size = new Size(238, 554);
            loansLabel.TabIndex = 1;
            loansLabel.Text = "Books currently on loan: 5";
            loansLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // membersLabel
            // 
            membersLabel.Dock = DockStyle.Fill;
            membersLabel.Location = new Point(491, 0);
            membersLabel.Name = "membersLabel";
            membersLabel.Size = new Size(238, 554);
            membersLabel.TabIndex = 2;
            membersLabel.Text = "Registered members: 12";
            membersLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // overdueLabel
            // 
            overdueLabel.Dock = DockStyle.Fill;
            overdueLabel.Location = new Point(735, 0);
            overdueLabel.Name = "overdueLabel";
            overdueLabel.Size = new Size(238, 554);
            overdueLabel.TabIndex = 3;
            overdueLabel.Text = "Overdue books: 1";
            overdueLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1000, 650);
            Controls.Add(reportGroup);
            Controls.Add(titleLabel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "ReportsForm";
            Text = "Reports";
            reportGroup.ResumeLayout(false);
            summaryTable.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
    }
}