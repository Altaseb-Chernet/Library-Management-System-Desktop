namespace LibraryManagementSystem.Forms
{
    partial class BooksForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private TableLayoutPanel managementLayout;
        private System.Windows.Forms.DataGridView booksGrid;
        private System.Windows.Forms.GroupBox editorGroup;
        private System.Windows.Forms.Label bookTitleLabel;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;

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
            titleLabel = new Label();
            managementLayout = new TableLayoutPanel();
            booksGrid = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            editorGroup = new GroupBox();
            bookTitleLabel = new Label();
            authorLabel = new Label();
            titleTextBox = new TextBox();
            authorTextBox = new TextBox();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            managementLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)booksGrid).BeginInit();
            editorGroup.SuspendLayout();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            titleLabel.Location = new Point(0, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(123, 48);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Books";
            // 
            // managementLayout
            // 
            managementLayout.ColumnCount = 2;
            managementLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
            managementLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            managementLayout.Controls.Add(booksGrid, 0, 0);
            managementLayout.Controls.Add(editorGroup, 1, 0);
            managementLayout.Dock = DockStyle.Fill;
            managementLayout.Location = new Point(0, 48);
            managementLayout.Name = "managementLayout";
            managementLayout.Padding = new Padding(0, 0, 25, 25);
            managementLayout.RowCount = 1;
            managementLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            managementLayout.Size = new Size(1156, 634);
            managementLayout.TabIndex = 0;
            // 
            // booksGrid
            // 
            booksGrid.AllowUserToAddRows = false;
            booksGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            booksGrid.BackgroundColor = Color.White;
            booksGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            booksGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            booksGrid.Dock = DockStyle.Fill;
            booksGrid.Location = new Point(0, 0);
            booksGrid.Margin = new Padding(0, 0, 8, 0);
            booksGrid.Name = "booksGrid";
            booksGrid.ReadOnly = true;
            booksGrid.RowHeadersWidth = 62;
            booksGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            booksGrid.Size = new Size(715, 609);
            booksGrid.TabIndex = 1;
            booksGrid.SelectionChanged += BooksGrid_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Title";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Author";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Status";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // editorGroup
            // 
            editorGroup.Controls.Add(bookTitleLabel);
            editorGroup.Controls.Add(authorLabel);
            editorGroup.Controls.Add(titleTextBox);
            editorGroup.Controls.Add(authorTextBox);
            editorGroup.Controls.Add(addButton);
            editorGroup.Controls.Add(editButton);
            editorGroup.Controls.Add(deleteButton);
            editorGroup.Dock = DockStyle.Fill;
            editorGroup.Location = new Point(731, 0);
            editorGroup.Margin = new Padding(8, 0, 0, 0);
            editorGroup.Name = "editorGroup";
            editorGroup.Size = new Size(400, 609);
            editorGroup.TabIndex = 2;
            editorGroup.TabStop = false;
            editorGroup.Text = "Book details";
            // 
            // bookTitleLabel
            // 
            bookTitleLabel.AutoSize = true;
            bookTitleLabel.Location = new Point(18, 38);
            bookTitleLabel.Name = "bookTitleLabel";
            bookTitleLabel.Size = new Size(44, 25);
            bookTitleLabel.TabIndex = 0;
            bookTitleLabel.Text = "Title";
            // 
            // authorLabel
            // 
            authorLabel.AutoSize = true;
            authorLabel.Location = new Point(18, 80);
            authorLabel.Name = "authorLabel";
            authorLabel.Size = new Size(67, 25);
            authorLabel.TabIndex = 1;
            authorLabel.Text = "Author";
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(80, 35);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(195, 31);
            titleTextBox.TabIndex = 2;
            // 
            // authorTextBox
            // 
            authorTextBox.Location = new Point(80, 77);
            authorTextBox.Name = "authorTextBox";
            authorTextBox.Size = new Size(195, 31);
            authorTextBox.TabIndex = 3;
            // 
            // addButton
            // 
            addButton.Location = new Point(18, 130);
            addButton.Name = "addButton";
            addButton.Size = new Size(80, 30);
            addButton.TabIndex = 4;
            addButton.Text = "Add";
            addButton.Click += AddButton_Click;
            // 
            // editButton
            // 
            editButton.Location = new Point(108, 130);
            editButton.Name = "editButton";
            editButton.Size = new Size(80, 30);
            editButton.TabIndex = 5;
            editButton.Text = "Edit";
            editButton.Click += EditButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Location = new Point(198, 130);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(80, 30);
            deleteButton.TabIndex = 6;
            deleteButton.Text = "Delete";
            deleteButton.Click += DeleteButton_Click;
            // 
            // BooksForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1156, 682);
            Controls.Add(managementLayout);
            Controls.Add(titleLabel);
            MinimumSize = new Size(700, 380);
            Name = "BooksForm";
            Text = "Books";
            managementLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)booksGrid).EndInit();
            editorGroup.ResumeLayout(false);
            editorGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}