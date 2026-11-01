using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms;

public partial class StaffForm : Form
{
    private readonly LibraryService libraryService;

    public StaffForm() : this(new LibraryService())
    {
    }

    public StaffForm(LibraryService service)
    {
        libraryService = service;
        InitializeComponent();
        RefreshStaff();
    }

    private void RefreshStaff()
    {
        staffGrid.Rows.Clear();
        foreach (var staff in libraryService.Staff)
            staffGrid.Rows.Add(staff.Id, staff.Username, staff.Role);
    }

    private void StaffGrid_SelectionChanged(object? sender, EventArgs e)
    {
        if (staffGrid.CurrentRow is null || staffGrid.CurrentRow.Index < 0 || staffGrid.CurrentRow.Index >= libraryService.Staff.Count)
            return;

        var staff = libraryService.Staff[staffGrid.CurrentRow.Index];
        usernameTextBox.Text = staff.Username;
        passwordTextBox.Text = staff.Password;
        roleComboBox.Text = staff.Role;
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        try
        {
            libraryService.AddStaff(usernameTextBox.Text, passwordTextBox.Text, roleComboBox.Text);
            RefreshStaff();
            ClearInputs();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private void EditButton_Click(object? sender, EventArgs e)
    {
        var staff = SelectedStaff();
        if (staff is null)
            return;

        staff.Username = usernameTextBox.Text.Trim();
        staff.Password = passwordTextBox.Text;
        staff.Role = roleComboBox.Text;
        RefreshStaff();
    }

    private void DeleteButton_Click(object? sender, EventArgs e)
    {
        var staff = SelectedStaff();
        if (staff is null)
            return;

        try
        {
            libraryService.DeleteStaff(staff);
            RefreshStaff();
            ClearInputs();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Staff", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private StaffMember? SelectedStaff() =>
        staffGrid.CurrentRow is null || staffGrid.CurrentRow.Index >= libraryService.Staff.Count
            ? null
            : libraryService.Staff[staffGrid.CurrentRow.Index];

    private void ClearInputs()
    {
        usernameTextBox.Clear();
        passwordTextBox.Clear();
        roleComboBox.SelectedIndex = 0;
    }
}
