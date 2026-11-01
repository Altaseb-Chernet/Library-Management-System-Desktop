namespace LibraryManagementSystem.Forms
{
    partial class IssueReturnForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label titleLabel;
        private GroupBox actionGroup;
        private Label memberLabel;
        private Label bookLabel;
        private ComboBox memberComboBox;
        private ComboBox bookComboBox;
        private Button issueButton;
        private Button returnButton;
        private Label messageLabel;
        private DataGridView loansGrid;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            titleLabel = new Label();
            actionGroup = new GroupBox();
            memberLabel = new Label();
            bookLabel = new Label();
            memberComboBox = new ComboBox();
            bookComboBox = new ComboBox();
            issueButton = new Button();
            returnButton = new Button();
            messageLabel = new Label();
            loansGrid = new DataGridView();
            actionGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)loansGrid).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(25, 20);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(164, 32);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Issue / Return";
            // 
            // actionGroup
            // 
            actionGroup.Controls.Add(memberLabel);
            actionGroup.Controls.Add(bookLabel);
            actionGroup.Controls.Add(memberComboBox);
            actionGroup.Controls.Add(bookComboBox);
            actionGroup.Controls.Add(issueButton);
            actionGroup.Controls.Add(returnButton);
            actionGroup.Controls.Add(messageLabel);
            actionGroup.Location = new Point(25, 75);
            actionGroup.Name = "actionGroup";
            actionGroup.Size = new Size(500, 220);
            actionGroup.TabIndex = 1;
            actionGroup.TabStop = false;
            actionGroup.Text = "Record a lending action";
            // 
            // memberLabel
            // 
            memberLabel.AutoSize = true;
            memberLabel.Location = new Point(25, 39);
            memberLabel.Name = "memberLabel";
            memberLabel.Size = new Size(49, 15);
            memberLabel.TabIndex = 0;
            memberLabel.Text = "Member";
            // 
            // bookLabel
            // 
            bookLabel.AutoSize = true;
            bookLabel.Location = new Point(25, 82);
            bookLabel.Name = "bookLabel";
            bookLabel.Size = new Size(37, 15);
            bookLabel.TabIndex = 1;
            bookLabel.Text = "Book";
            // 
            // memberComboBox
            // 
            memberComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            memberComboBox.FormattingEnabled = true;
            memberComboBox.Items.AddRange(new object[] { "M-001 - Amina Yusuf", "M-002 - Daniel Smith", "M-003 - Sara Ahmed" });
            memberComboBox.Location = new Point(170, 35);
            memberComboBox.Name = "memberComboBox";
            memberComboBox.Size = new Size(260, 23);
            memberComboBox.TabIndex = 2;
            // 
            // bookComboBox
            // 
            bookComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bookComboBox.FormattingEnabled = true;
            bookComboBox.Items.AddRange(new object[] { "B-001 - The Hobbit", "B-003 - Pride and Prejudice" });
            bookComboBox.Location = new Point(170, 78);
            bookComboBox.Name = "bookComboBox";
            bookComboBox.Size = new Size(260, 23);
            bookComboBox.TabIndex = 3;
            // 
            // issueButton
            // 
            issueButton.Location = new Point(170, 130);
            issueButton.Name = "issueButton";
            issueButton.Size = new Size(120, 32);
            issueButton.TabIndex = 4;
            issueButton.Text = "Issue book";
            issueButton.UseVisualStyleBackColor = true;
            issueButton.Click += IssueButton_Click;
            // 
            // returnButton
            // 
            returnButton.Location = new Point(310, 130);
            returnButton.Name = "returnButton";
            returnButton.Size = new Size(120, 32);
            returnButton.TabIndex = 5;
            returnButton.Text = "Return book";
            returnButton.UseVisualStyleBackColor = true;
            returnButton.Click += ReturnButton_Click;
            // 
            // messageLabel
            // 
            messageLabel.AutoSize = true;
            messageLabel.ForeColor = Color.DimGray;
            messageLabel.Location = new Point(25, 180);
            messageLabel.Name = "messageLabel";
            messageLabel.Size = new Size(257, 15);
            messageLabel.TabIndex = 6;
            messageLabel.Text = "Choose a member and book, then select an action.";
            // 
            // loansGrid
            // 
            loansGrid.AllowUserToAddRows = false;
            loansGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            loansGrid.BackgroundColor = Color.White;
            loansGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            loansGrid.Location = new Point(25, 320);
            loansGrid.Name = "loansGrid";
            loansGrid.ReadOnly = true;
            loansGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            loansGrid.Size = new Size(845, 150);
            loansGrid.TabIndex = 7;
            loansGrid.Columns.Add("Id", "ID");
            loansGrid.Columns.Add("Book", "Book");
            loansGrid.Columns.Add("Member", "Member");
            loansGrid.Columns.Add("Issued", "Issued");
            loansGrid.Columns.Add("Returned", "Returned");
            // 
            // IssueReturnForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
            ClientSize = new Size(900, 500);
        MinimumSize = new Size(700, 450);
            Controls.Add(titleLabel);
            Controls.Add(actionGroup);
            Controls.Add(loansGrid);
        loansGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        actionGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            Name = "IssueReturnForm";
            Text = "Issue and return";
            actionGroup.ResumeLayout(false);
            actionGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)loansGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}