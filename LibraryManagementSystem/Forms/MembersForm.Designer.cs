namespace LibraryManagementSystem.Forms
{
    partial class MembersForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private TableLayoutPanel managementLayout;
        private System.Windows.Forms.DataGridView membersGrid;
        private System.Windows.Forms.GroupBox editorGroup;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox phoneTextBox;
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
            membersGrid = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            editorGroup = new GroupBox();
            nameLabel = new Label();
            phoneLabel = new Label();
            nameTextBox = new TextBox();
            phoneTextBox = new TextBox();
            addButton = new Button();
            editButton = new Button();
            deleteButton = new Button();
            managementLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)membersGrid).BeginInit();
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
            titleLabel.Size = new Size(177, 48);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Members";
            // 
            // managementLayout
            // 
            managementLayout.ColumnCount = 2;
            managementLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
            managementLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            managementLayout.Controls.Add(membersGrid, 0, 0);
            managementLayout.Controls.Add(editorGroup, 1, 0);
            managementLayout.Dock = DockStyle.Fill;
            managementLayout.Location = new Point(0, 48);
            managementLayout.Name = "managementLayout";
            managementLayout.Padding = new Padding(0, 0, 25, 25);
            managementLayout.RowCount = 1;
            managementLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            managementLayout.Size = new Size(900, 382);
            managementLayout.TabIndex = 0;
            // 
            // membersGrid
            // 
            membersGrid.AllowUserToAddRows = false;
            membersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            membersGrid.BackgroundColor = Color.White;
            membersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            membersGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            membersGrid.Dock = DockStyle.Fill;
            membersGrid.Location = new Point(0, 0);
            membersGrid.Margin = new Padding(0, 0, 8, 0);
            membersGrid.Name = "membersGrid";
            membersGrid.ReadOnly = true;
            membersGrid.RowHeadersWidth = 62;
            membersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            membersGrid.Size = new Size(552, 357);
            membersGrid.TabIndex = 1;
            membersGrid.SelectionChanged += MembersGrid_SelectionChanged;
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
            dataGridViewTextBoxColumn2.HeaderText = "Name";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Phone";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Books out";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // editorGroup
            // 
            editorGroup.Controls.Add(nameLabel);
            editorGroup.Controls.Add(phoneLabel);
            editorGroup.Controls.Add(nameTextBox);
            editorGroup.Controls.Add(phoneTextBox);
            editorGroup.Controls.Add(addButton);
            editorGroup.Controls.Add(editButton);
            editorGroup.Controls.Add(deleteButton);
            editorGroup.Dock = DockStyle.Fill;
            editorGroup.Location = new Point(568, 0);
            editorGroup.Margin = new Padding(8, 0, 0, 0);
            editorGroup.Name = "editorGroup";
            editorGroup.Size = new Size(307, 357);
            editorGroup.TabIndex = 2;
            editorGroup.TabStop = false;
            editorGroup.Text = "Member details";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(18, 38);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(59, 25);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name";
            // 
            // phoneLabel
            // 
            phoneLabel.AutoSize = true;
            phoneLabel.Location = new Point(18, 80);
            phoneLabel.Name = "phoneLabel";
            phoneLabel.Size = new Size(62, 25);
            phoneLabel.TabIndex = 1;
            phoneLabel.Text = "Phone";
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(80, 35);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(195, 31);
            nameTextBox.TabIndex = 2;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(80, 77);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(195, 31);
            phoneTextBox.TabIndex = 3;
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
            // MembersForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(900, 430);
            Controls.Add(managementLayout);
            Controls.Add(titleLabel);
            MinimumSize = new Size(700, 380);
            Name = "MembersForm";
            Text = "Members";
            managementLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)membersGrid).EndInit();
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