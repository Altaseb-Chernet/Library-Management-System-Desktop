using LibraryApp.Models;
using LibraryApp.Services;

namespace LibraryApp.Forms;

public class BooksForm : ChildForm
{
    private readonly ListView list = Ui.MakeList(
        ("ID", 45), ("Title", 240), ("Author", 160), ("ISBN", 120), ("Category", 120), ("Copies", 60), ("Available", 70));

    private readonly TextBox txtSearch = new() { PlaceholderText = "Search by title, author or ISBN", Width = 300, Location = new Point(12, 14) };
    private readonly ComboBox cmbFilter = new() { DropDownStyle = ComboBoxStyle.DropDownList, Width = 180, Location = new Point(325, 14) };

    private readonly TextBox txtTitle = new() { Location = new Point(15, 40), Width = 270 };
    private readonly TextBox txtAuthor = new() { Location = new Point(15, 95), Width = 270 };
    private readonly TextBox txtIsbn = new() { Location = new Point(15, 150), Width = 270 };
    private readonly ComboBox cmbCategory = new() { DropDownStyle = ComboBoxStyle.DropDown, Location = new Point(15, 205), Width = 270 };
    private readonly NumericUpDown numCopies = new() { Location = new Point(15, 260), Width = 100, Minimum = 0, Maximum = 500, Value = 1 };

    private readonly Button btnAdd = Ui.MakeButton("Add", 15, 315, 85, primary: true);
    private readonly Button btnUpdate = Ui.MakeButton("Update", 108, 315, 85);
    private readonly Button btnDelete = Ui.MakeButton("Delete", 201, 315, 85);
    private readonly Button btnClear = Ui.MakeButton("Clear form", 15, 355, 271);

    private readonly ErrorProvider errors = new() { BlinkStyle = ErrorBlinkStyle.NeverBlink };
    private bool refreshing;

    public BooksForm()
    {
        var top = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = Ui.Panel };
        top.Controls.AddRange(new Control[] { txtSearch, cmbFilter });

        var right = new Panel { Dock = DockStyle.Right, Width = 305, BackColor = Ui.Panel };
        right.Controls.Add(Ui.MakeLabel("Book details", 15, 8, bold: true));
        right.Controls.Add(Ui.MakeLabel("Title", 15, 22));
        right.Controls.Add(txtTitle);
        right.Controls.Add(Ui.MakeLabel("Author", 15, 77));
        right.Controls.Add(txtAuthor);
        right.Controls.Add(Ui.MakeLabel("ISBN (10 or 13 digits)", 15, 132));
        right.Controls.Add(txtIsbn);
        right.Controls.Add(Ui.MakeLabel("Category", 15, 187));
        right.Controls.Add(cmbCategory);
        right.Controls.Add(Ui.MakeLabel("Number of copies", 15, 242));
        right.Controls.Add(numCopies);
        right.Controls.AddRange(new Control[] { btnAdd, btnUpdate, btnDelete, btnClear });

        // Fill control first, then side/top panels
        Controls.Add(list);
        Controls.Add(right);
        Controls.Add(top);

        // ---- events ----
        txtSearch.TextChanged += (_, _) => RefreshData();
        cmbFilter.SelectedIndexChanged += (_, _) => { if (!refreshing) RefreshData(); };
        list.SelectedIndexChanged += (_, _) => LoadSelected();
        btnAdd.Click += (_, _) => AddBook();
        btnUpdate.Click += (_, _) => UpdateBook();
        btnDelete.Click += (_, _) => DeleteBook();
        btnClear.Click += (_, _) => ClearForm();
        list.DoubleClick += (_, _) => txtTitle.Focus();
        txtIsbn.KeyPress += (_, e) =>
        {
            // only digits, dash and control keys
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-') e.Handled = true;
        };
        btnUpdate.Enabled = btnDelete.Enabled = false;
    }

    protected override void RefreshData()
    {
        refreshing = true;
        int? keepId = Ui.SelectedId(list);

        // category filter + category suggestions
        string? previous = cmbFilter.SelectedItem as string;
        var cats = LibraryService.Categories();
        cmbFilter.Items.Clear();
        cmbFilter.Items.Add("All categories");
        cmbFilter.Items.AddRange(cats.ToArray());
        cmbFilter.SelectedItem = previous != null && cmbFilter.Items.Contains(previous) ? previous : "All categories";

        string typed = cmbCategory.Text;
        cmbCategory.Items.Clear();
        cmbCategory.Items.AddRange(cats.ToArray());
        cmbCategory.Text = typed;

        string? cat = cmbFilter.SelectedIndex > 0 ? cmbFilter.SelectedItem as string : null;
        var books = LibraryService.SearchBooks(txtSearch.Text, cat);

        list.BeginUpdate();
        list.Items.Clear();
        foreach (var b in books)
        {
            var item = Ui.Row(b.Id, b.Id.ToString(), b.Title, b.Author, b.Isbn, b.Category,
                b.TotalCopies.ToString(), b.AvailableCopies.ToString());
            if (b.AvailableCopies == 0) item.ForeColor = Ui.Danger;
            list.Items.Add(item);
            if (keepId == b.Id) item.Selected = true;
        }
        list.EndUpdate();
        refreshing = false;
        MainForm.SetStatus($"{books.Count} book(s) shown.");
    }

    private void LoadSelected()
    {
        if (refreshing) return;
        var id = Ui.SelectedId(list);
        btnUpdate.Enabled = btnDelete.Enabled = id != null;
        btnAdd.Enabled = id == null;
        errors.Clear();
        if (id == null) return;
        var b = LibraryService.GetBook(id.Value);
        if (b == null) return;
        txtTitle.Text = b.Title; txtAuthor.Text = b.Author; txtIsbn.Text = b.Isbn;
        cmbCategory.Text = b.Category; numCopies.Value = b.TotalCopies;
    }

    private bool ValidateInput()
    {
        errors.Clear();
        bool ok = true;
        void Fail(Control c, string msg) { errors.SetError(c, msg); ok = false; }

        if (string.IsNullOrWhiteSpace(txtTitle.Text)) Fail(txtTitle, "Title is required.");
        if (string.IsNullOrWhiteSpace(txtAuthor.Text)) Fail(txtAuthor, "Author is required.");

        string digits = txtIsbn.Text.Replace("-", "").Trim();
        if (digits.Length != 10 && digits.Length != 13 || !digits.All(char.IsDigit))
            Fail(txtIsbn, "ISBN must contain 10 or 13 digits.");

        if (string.IsNullOrWhiteSpace(cmbCategory.Text)) Fail(cmbCategory, "Category is required.");
        if (numCopies.Value < 1) Fail(numCopies, "At least 1 copy is required.");

        if (!ok) MainForm.SetStatus("Please correct the highlighted fields.", true);
        return ok;
    }

    private void AddBook()
    {
        if (!ValidateInput()) return;
        var r = LibraryService.AddBook(txtTitle.Text, txtAuthor.Text, txtIsbn.Text, cmbCategory.Text, (int)numCopies.Value);
        Report(r);
        if (r.Ok) ClearForm();
    }

    private void UpdateBook()
    {
        var id = Ui.SelectedId(list);
        if (id == null || !ValidateInput()) return;
        var r = LibraryService.UpdateBook(id.Value, txtTitle.Text, txtAuthor.Text, txtIsbn.Text, cmbCategory.Text, (int)numCopies.Value);
        Report(r);
    }

    private void DeleteBook()
    {
        var id = Ui.SelectedId(list);
        if (id == null) return;
        if (!Ui.Confirm("Delete the selected book?")) return;
        var r = LibraryService.DeleteBook(id.Value);
        Report(r);
        if (r.Ok) ClearForm();
        else MessageBox.Show(r.Message, "Cannot delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private void ClearForm()
    {
        errors.Clear();
        list.SelectedItems.Clear();
        txtTitle.Clear(); txtAuthor.Clear(); txtIsbn.Clear();
        cmbCategory.Text = "";
        numCopies.Value = 1;
        btnAdd.Enabled = true;
        btnUpdate.Enabled = btnDelete.Enabled = false;
        txtTitle.Focus();
    }
}
