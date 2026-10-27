using System.Text.RegularExpressions;
using LibraryApp.Services;

namespace LibraryApp.Forms;

public class MembersForm : ChildForm
{
    private readonly ListView list = Ui.MakeList(
        ("ID", 70), ("Name", 190), ("Email", 210), ("Phone", 110), ("Joined", 100), ("Status", 80), ("Loans", 60));

    private readonly TextBox txtSearch = new() { PlaceholderText = "Search by name, email, phone or ID", Width = 320, Location = new Point(12, 14) };

    private readonly TextBox txtName = new() { Location = new Point(15, 40), Width = 270 };
    private readonly TextBox txtEmail = new() { Location = new Point(15, 95), Width = 270 };
    private readonly TextBox txtPhone = new() { Location = new Point(15, 150), Width = 270 };
    private readonly CheckBox chkActive = new() { Text = "Active member", Checked = true, Location = new Point(15, 190), AutoSize = true };

    private readonly Button btnAdd = Ui.MakeButton("Register", 15, 235, 85, primary: true);
    private readonly Button btnUpdate = Ui.MakeButton("Update", 108, 235, 85);
    private readonly Button btnDelete = Ui.MakeButton("Delete", 201, 235, 85);
    private readonly Button btnClear = Ui.MakeButton("Clear form", 15, 275, 271);

    private readonly ErrorProvider errors = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
    private bool refreshing;

    private static readonly Regex EmailPattern = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    private static readonly Regex PhonePattern = new(@"^\+?\d{9,15}$");

    public MembersForm()
    {
        var top = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = Ui.Panel };
        top.Controls.Add(txtSearch);

        var right = new Panel { Dock = DockStyle.Right, Width = 305, BackColor = Ui.Panel };
        right.Controls.Add(Ui.MakeLabel("Member details", 15, 8, bold: true));
        right.Controls.Add(Ui.MakeLabel("Full name", 15, 22));
        right.Controls.Add(txtName);
        right.Controls.Add(Ui.MakeLabel("Email", 15, 77));
        right.Controls.Add(txtEmail);
        right.Controls.Add(Ui.MakeLabel("Phone", 15, 132));
        right.Controls.Add(txtPhone);
        right.Controls.Add(chkActive);
        right.Controls.AddRange(new Control[] { btnAdd, btnUpdate, btnDelete, btnClear });

        Controls.Add(list);
        Controls.Add(right);
        Controls.Add(top);

        txtSearch.TextChanged += (_, _) => RefreshData();
        list.SelectedIndexChanged += (_, _) => LoadSelected();
        btnAdd.Click += (_, _) => AddMember();
        btnUpdate.Click += (_, _) => UpdateMember();
        btnDelete.Click += (_, _) => DeleteMember();
        btnClear.Click += (_, _) => ClearForm();
        btnUpdate.Enabled = btnDelete.Enabled = false;
    }

    protected override void RefreshData()
    {
        refreshing = true;
        int? keepId = Ui.SelectedId(list);
        var members = LibraryService.SearchMembers(txtSearch.Text);

        list.BeginUpdate();
        list.Items.Clear();
        foreach (var m in members)
        {
            var item = Ui.Row(m.Id, m.Code, m.Name, m.Email, m.Phone, m.JoinDate.ToString("dd MMM yyyy"),
                m.IsActive ? "Active" : "Inactive", LibraryService.ActiveLoansOf(m.Id).ToString());
            if (!m.IsActive) item.ForeColor = Color.Gray;
            list.Items.Add(item);
            if (keepId == m.Id) item.Selected = true;
        }
        list.EndUpdate();
        refreshing = false;
        MainForm.SetStatus($"{members.Count} member(s) shown.");
    }

    private void LoadSelected()
    {
        if (refreshing) return;
        var id = Ui.SelectedId(list);
        btnUpdate.Enabled = btnDelete.Enabled = id != null;
        btnAdd.Enabled = id == null;
        errors.Clear();
        if (id == null) return;
        var m = LibraryService.GetMember(id.Value);
        if (m == null) return;
        txtName.Text = m.Name; txtEmail.Text = m.Email; txtPhone.Text = m.Phone; chkActive.Checked = m.IsActive;
    }

    private bool ValidateInput()
    {
        errors.Clear();
        bool ok = true;
        void Fail(Control c, string msg) { errors.SetError(c, msg); ok = false; }

        if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Trim().Length < 3)
            Fail(txtName, "Enter the full name (at least 3 characters).");
        if (!EmailPattern.IsMatch(txtEmail.Text.Trim()))
            Fail(txtEmail, "Enter a valid email address.");
        if (!PhonePattern.IsMatch(txtPhone.Text.Trim()))
            Fail(txtPhone, "Phone must be 9 to 15 digits (optional + at the start).");

        if (!ok) MainForm.SetStatus("Please correct the highlighted fields.", true);
        return ok;
    }

    private void AddMember()
    {
        if (!ValidateInput()) return;
        var r = LibraryService.AddMember(txtName.Text, txtEmail.Text, txtPhone.Text);
        Report(r);
        if (r.Ok) ClearForm();
    }

    private void UpdateMember()
    {
        var id = Ui.SelectedId(list);
        if (id == null || !ValidateInput()) return;
        Report(LibraryService.UpdateMember(id.Value, txtName.Text, txtEmail.Text, txtPhone.Text, chkActive.Checked));
    }

    private void DeleteMember()
    {
        var id = Ui.SelectedId(list);
        if (id == null) return;
        if (!Ui.Confirm("Delete the selected member?")) return;
        var r = LibraryService.DeleteMember(id.Value);
        Report(r);
        if (r.Ok) ClearForm();
        else MessageBox.Show(r.Message, "Cannot delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void ClearForm()
    {
        errors.Clear();
        list.SelectedItems.Clear();
        txtName.Clear(); txtEmail.Clear(); txtPhone.Clear();
        chkActive.Checked = true;
        btnAdd.Enabled = true;
        btnUpdate.Enabled = btnDelete.Enabled = false;
        txtName.Focus();
    }
}
