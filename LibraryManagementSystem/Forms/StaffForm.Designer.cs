namespace LibraryManagementSystem.Forms;

partial class StaffForm
{
    private System.ComponentModel.IContainer components = null;
    private Label titleLabel;
    private TableLayoutPanel managementLayout;
    private DataGridView staffGrid;
    private GroupBox editorGroup;
    private Label usernameLabel;
    private Label passwordLabel;
    private Label roleLabel;
    private TextBox usernameTextBox;
    private TextBox passwordTextBox;
    private ComboBox roleComboBox;
    private Button addButton;
    private Button editButton;
    private Button deleteButton;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        titleLabel = new Label();
        managementLayout = new TableLayoutPanel();
        staffGrid = new DataGridView();
        dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
        dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
        editorGroup = new GroupBox();
        usernameLabel = new Label();
        passwordLabel = new Label();
        roleLabel = new Label();
        usernameTextBox = new TextBox();
        passwordTextBox = new TextBox();
        roleComboBox = new ComboBox();
        addButton = new Button();
        editButton = new Button();
        deleteButton = new Button();
        managementLayout.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)staffGrid).BeginInit();
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
        titleLabel.Size = new Size(259, 48);
        titleLabel.TabIndex = 0;
        titleLabel.Text = "Staff accounts";
        // 
        // managementLayout
        // 
        managementLayout.ColumnCount = 2;
        managementLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
        managementLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
        managementLayout.Controls.Add(staffGrid, 0, 0);
        managementLayout.Controls.Add(editorGroup, 1, 0);
        managementLayout.Dock = DockStyle.Fill;
        managementLayout.Location = new Point(0, 48);
        managementLayout.Name = "managementLayout";
        managementLayout.Padding = new Padding(25, 0, 25, 25);
        managementLayout.RowCount = 1;
        managementLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        managementLayout.Size = new Size(900, 382);
        managementLayout.TabIndex = 0;
        // 
        // staffGrid
        // 
        staffGrid.AllowUserToAddRows = false;
        staffGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        staffGrid.BackgroundColor = Color.White;
        staffGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        staffGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
        staffGrid.Dock = DockStyle.Fill;
        staffGrid.Location = new Point(25, 0);
        staffGrid.Margin = new Padding(0, 0, 8, 0);
        staffGrid.Name = "staffGrid";
        staffGrid.ReadOnly = true;
        staffGrid.RowHeadersWidth = 62;
        staffGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        staffGrid.Size = new Size(536, 357);
        staffGrid.TabIndex = 1;
        staffGrid.SelectionChanged += StaffGrid_SelectionChanged;
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
        dataGridViewTextBoxColumn2.HeaderText = "Username";
        dataGridViewTextBoxColumn2.MinimumWidth = 8;
        dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
        dataGridViewTextBoxColumn2.ReadOnly = true;
        // 
        // dataGridViewTextBoxColumn3
        // 
        dataGridViewTextBoxColumn3.HeaderText = "Role";
        dataGridViewTextBoxColumn3.MinimumWidth = 8;
        dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
        dataGridViewTextBoxColumn3.ReadOnly = true;
        // 
        // editorGroup
        // 
        editorGroup.Controls.Add(usernameLabel);
        editorGroup.Controls.Add(passwordLabel);
        editorGroup.Controls.Add(roleLabel);
        editorGroup.Controls.Add(usernameTextBox);
        editorGroup.Controls.Add(passwordTextBox);
        editorGroup.Controls.Add(roleComboBox);
        editorGroup.Controls.Add(addButton);
        editorGroup.Controls.Add(editButton);
        editorGroup.Controls.Add(deleteButton);
        editorGroup.Dock = DockStyle.Fill;
        editorGroup.Location = new Point(577, 0);
        editorGroup.Margin = new Padding(8, 0, 0, 0);
        editorGroup.Name = "editorGroup";
        editorGroup.Size = new Size(298, 357);
        editorGroup.TabIndex = 2;
        editorGroup.TabStop = false;
        editorGroup.Text = "Staff details";
        // 
        // usernameLabel
        // 
        usernameLabel.AutoSize = true;
        usernameLabel.Location = new Point(18, 35);
        usernameLabel.Name = "usernameLabel";
        usernameLabel.Size = new Size(91, 25);
        usernameLabel.TabIndex = 0;
        usernameLabel.Text = "Username";
        // 
        // passwordLabel
        // 
        passwordLabel.AutoSize = true;
        passwordLabel.Location = new Point(18, 78);
        passwordLabel.Name = "passwordLabel";
        passwordLabel.Size = new Size(87, 25);
        passwordLabel.TabIndex = 1;
        passwordLabel.Text = "Password";
        // 
        // roleLabel
        // 
        roleLabel.AutoSize = true;
        roleLabel.Location = new Point(18, 121);
        roleLabel.Name = "roleLabel";
        roleLabel.Size = new Size(46, 25);
        roleLabel.TabIndex = 2;
        roleLabel.Text = "Role";
        // 
        // usernameTextBox
        // 
        usernameTextBox.Location = new Point(114, 32);
        usernameTextBox.Name = "usernameTextBox";
        usernameTextBox.Size = new Size(180, 31);
        usernameTextBox.TabIndex = 3;
        // 
        // passwordTextBox
        // 
        passwordTextBox.Location = new Point(114, 75);
        passwordTextBox.Name = "passwordTextBox";
        passwordTextBox.Size = new Size(180, 31);
        passwordTextBox.TabIndex = 4;
        // 
        // roleComboBox
        // 
        roleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        roleComboBox.Items.AddRange(new object[] { "Administrator", "Librarian" });
        roleComboBox.Location = new Point(114, 121);
        roleComboBox.Name = "roleComboBox";
        roleComboBox.Size = new Size(180, 33);
        roleComboBox.TabIndex = 5;
        // 
        // addButton
        // 
        addButton.Location = new Point(18, 170);
        addButton.Name = "addButton";
        addButton.Size = new Size(80, 30);
        addButton.TabIndex = 6;
        addButton.Text = "Add";
        addButton.Click += AddButton_Click;
        // 
        // editButton
        // 
        editButton.Location = new Point(108, 170);
        editButton.Name = "editButton";
        editButton.Size = new Size(80, 30);
        editButton.TabIndex = 7;
        editButton.Text = "Edit";
        editButton.Click += EditButton_Click;
        // 
        // deleteButton
        // 
        deleteButton.Location = new Point(198, 170);
        deleteButton.Name = "deleteButton";
        deleteButton.Size = new Size(80, 30);
        deleteButton.TabIndex = 8;
        deleteButton.Text = "Delete";
        deleteButton.Click += DeleteButton_Click;
        // 
        // StaffForm
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        AutoScroll = true;
        ClientSize = new Size(900, 430);
        Controls.Add(managementLayout);
        Controls.Add(titleLabel);
        MinimumSize = new Size(700, 380);
        Name = "StaffForm";
        Text = "Staff";
        managementLayout.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)staffGrid).EndInit();
        editorGroup.ResumeLayout(false);
        editorGroup.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
}
