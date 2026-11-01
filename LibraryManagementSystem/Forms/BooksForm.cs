using LibraryManagementSystem.Models;
using LibraryManagementSystem.Services;
using System.Windows.Forms;

namespace LibraryManagementSystem.Forms;

public partial class BooksForm : Form
{
    private readonly LibraryService libraryService;

    public BooksForm() : this(new LibraryService())
    {
    }

    public BooksForm(LibraryService service)
    {
        libraryService = service;
        InitializeComponent();
        RefreshBooks();
    }

    private void RefreshBooks()
    {
        booksGrid.Rows.Clear();
        foreach (var book in libraryService.Books)
            booksGrid.Rows.Add(book.Id, book.Title, book.Author, book.IsAvailable ? "Available" : "On loan");
    }

    private void BooksGrid_SelectionChanged(object? sender, EventArgs e)
    {
        var book = SelectedBook();
        if (book is null)
            return;
        titleTextBox.Text = book.Title;
        authorTextBox.Text = book.Author;
    }

    private void AddButton_Click(object? sender, EventArgs e)
    {
        if (!HasText())
            return;
        libraryService.AddBook(titleTextBox.Text, authorTextBox.Text);
        RefreshBooks();
        ClearInputs();
    }

    private void EditButton_Click(object? sender, EventArgs e)
    {
        var book = SelectedBook();
        if (book is null || !HasText())
            return;
        book.Title = titleTextBox.Text.Trim();
        book.Author = authorTextBox.Text.Trim();
        RefreshBooks();
    }

    private void DeleteButton_Click(object? sender, EventArgs e)
    {
        var book = SelectedBook();
        if (book is null)
            return;
        try
        {
            libraryService.DeleteBook(book);
            RefreshBooks();
            ClearInputs();
        }
        catch (InvalidOperationException ex)
        {
            MessageBox.Show(ex.Message, "Books", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private Book? SelectedBook() =>
        booksGrid.CurrentRow is null || booksGrid.CurrentRow.Index >= libraryService.Books.Count
            ? null
            : libraryService.Books[booksGrid.CurrentRow.Index];

    private bool HasText() => !string.IsNullOrWhiteSpace(titleTextBox.Text) && !string.IsNullOrWhiteSpace(authorTextBox.Text);

    private void ClearInputs()
    {
        titleTextBox.Clear();
        authorTextBox.Clear();
    }
}
