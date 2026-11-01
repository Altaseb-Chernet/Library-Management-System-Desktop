using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms;

public partial class MembersForm : Form
{
    private readonly LibraryService libraryService;

    public MembersForm() : this(new LibraryService())
    {
    }

    public MembersForm(LibraryService service)
    {
        libraryService = service;
        InitializeComponent();
        RefreshMembers();
    }

    private void RefreshMembers()
    {
        membersGrid.Rows.Clear();
        foreach (var member in libraryService.Members)
        {
            var activeLoans = libraryService.Loans.Count(x => x.MemberId == member.Id && !x.IsReturned);
            membersGrid.Rows.Add(member.Id, member.Name, member.Phone, activeLoans);
        }
    }

    private void MembersGrid_SelectionChanged(object? sender, EventArgs e)
    {
        var member = SelectedMember();
        if (member is null)
            return;
        nameTextBox.Text = member.Name;
        phoneTextBox.Text = member.Phone;
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        if (!HasText())
            return;
        libraryService.AddMember(nameTextBox.Text, phoneTextBox.Text);
        RefreshMembers();
        ClearInputs();
    }

    private void EditButton_Click(object? sender, EventArgs e)
    {
        var member = SelectedMember();
        if (member is null || !HasText())
            return;
        member.Name = nameTextBox.Text.Trim();
        member.Phone = phoneTextBox.Text.Trim();
        RefreshMembers();
    }

    private void DeleteButton_Click(object? sender, EventArgs e)
    {
        var member = SelectedMember();
        if (member is null)
            return;
        try
        {
            libraryService.DeleteMember(member);
            RefreshMembers();
            ClearInputs();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Members", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private Member? SelectedMember() =>
        membersGrid.CurrentRow is null || membersGrid.CurrentRow.Index >= libraryService.Members.Count
            ? null
            : libraryService.Members[membersGrid.CurrentRow.Index];

    private bool HasText() => !string.IsNullOrWhiteSpace(nameTextBox.Text) && !string.IsNullOrWhiteSpace(phoneTextBox.Text);

    private void ClearInputs()
    {
        nameTextBox.Clear();
        phoneTextBox.Clear();
    }
}
