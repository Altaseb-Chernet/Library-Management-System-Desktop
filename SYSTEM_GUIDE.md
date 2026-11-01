# Library Management System Guide

## 1. What problem does this system solve?

A small library needs a simple way to keep track of books, members, staff, and lending activity. This application puts those tasks in one Windows Forms window so staff do not need separate screens or paper lists for every action.

The project is a learning/sample system. It keeps data in memory while the application is open. It does not use a database or save changes to a file.

## 2. How the application is organized

The application starts with `Form1`, which acts as a small startup launcher:

1. It creates one `LibraryService` instance.
2. It opens the login form.
3. After a successful login, it opens `MainForm` and passes the same service instance and user role.
4. All tabs use that same service, so an added book or returned loan is immediately visible in other tabs.

The important folders are:

- `Models` - simple data classes such as `Book`, `Member`, `Loan`, and `StaffMember`.
- `Services` - application rules and in-memory sample data.
- `Forms` - the visible Windows Forms pages and their designer layouts.

## 3. Login and roles

The login form checks the username and password using `LibraryService.ValidateLogin`.

| Role | Username | Password |
| --- | --- | --- |
| Administrator | `admin` | `admin123` |
| Librarian | `librarian` | `library123` |

### Librarian responsibility

A librarian can:

- Add, edit, and delete books.
- Add, edit, and delete members.
- Issue an available book to a member.
- Return a selected loan.
- View the Home, Books, Members, Issue / Return, and Reports tabs.

### Administrator responsibility

An administrator can do everything a librarian can do, and can also:

- Add, edit, and delete staff accounts.
- Choose whether a new staff account is an Administrator or Librarian.
- View staff and library summary reports.

The Staff tab is only added to the main window when the logged-in role is `Administrator`.

## 4. MainForm and the GroupBox layout

`MainForm` is the main shell of the application. It has three important controls:

- `headerLabel` - the blue title area at the top. It also shows the current role.
- `tabs` - the `TabControl` across the top. Each tab represents one responsibility.
- `pageGroup` - the `Workspace` `GroupBox` below the tabs.

The other forms are hosted inside `pageGroup`. When a tab is selected, `ShowPage`:

1. Removes the previous page from the GroupBox.
2. Sets the selected form to `TopLevel = false`.
3. Removes its border.
4. Docks it to fill the GroupBox.
5. Shows it inside the main window.

This solves the problem of many separate windows and gives the application one consistent workspace.

## 5. Explanation of every tab

### Home

`HomeForm` is the starting page. It gives a quick summary:

- Total books.
- Total members.
- Current active loans.

The values come from the shared service, so the numbers change when records are added or loans are returned.

### Books

`BooksForm` manages the book catalogue.

The grid displays:

- Book ID.
- Title.
- Author.
- Availability status.

The Book details GroupBox contains the title and author fields and the Add, Edit, and Delete buttons.

Rules:

- Add creates a new book in memory.
- Edit changes the selected book.
- Delete removes the selected book.
- A book with an active loan cannot be deleted.

### Members

`MembersForm` manages people who borrow books.

The grid displays:

- Member ID.
- Name.
- Phone.
- Number of active books.

The Member details GroupBox contains the name and phone fields and the Add, Edit, and Delete buttons.

Rules:

- Add creates a new member.
- Edit changes the selected member.
- Delete removes the selected member.
- A member with an active loan cannot be deleted.

### Issue / Return

`IssueReturnForm` manages lending activity.

The action GroupBox contains:

- A member selector.
- An available-book selector.
- An Issue book button.
- A Return selected button.
- A small status message.

The loan history grid displays:

- Loan ID.
- Book.
- Member.
- Issue date.
- Return date or `Active`.

When a book is issued, the service marks it unavailable and creates a `Loan`. When a loan is returned, the service stores the return date and makes the book available again.

### Staff

`StaffForm` is an administrator-only page.

The grid displays staff IDs, usernames, and roles. The Staff details GroupBox contains username, password, role, and Add, Edit, and Delete buttons.

Rules:

- Usernames must be unique when adding staff.
- The last administrator cannot be deleted.
- Staff changes are kept in memory only.

### Reports

`ReportsForm` gives a simple live summary of:

- Total books.
- Books currently on loan.
- Registered members.
- Overdue books.

It is a summary page, not a separate data store. Its values are calculated from the shared service.

## 6. Models

### `Book`

Stores the book ID, title, author, and `IsAvailable` state.

### `Member`

Stores the member ID, name, and phone number.

### `Loan`

Connects one book to one member. It stores the issue date and optional return date. The `IsReturned` property indicates whether the loan is complete.

### `StaffMember`

Stores a username, password, ID, and role. This is intentionally simple for a learning project and is not secure enough for production authentication.

## 7. LibraryService

`LibraryService` is the application’s in-memory service layer. It owns the lists of books, members, loans, and staff.

It is responsible for:

- Loading sample records.
- Validating login credentials.
- Adding and deleting books.
- Adding and deleting members.
- Issuing and returning loans.
- Adding and deleting staff.
- Protecting basic rules such as blocking deletion of a book on loan.

Keeping these rules in the service prevents each form from implementing its own version of the same business logic.

## 8. Designer support

Each form has a `.cs` file and a `.Designer.cs` file:

- The `.cs` file contains behavior such as button clicks and service calls.
- The `.Designer.cs` file contains controls, sizes, locations, fonts, and layout.

The controls are declared in the Designer files so Visual Studio can open each form in Design view. You can select and resize the GroupBoxes, labels, grids, text boxes, buttons, and tabs manually.

Each form also has a parameterless constructor for Visual Studio Designer support. The running application uses the constructor that receives the shared `LibraryService`.

## 9. Current limitation

Closing the application clears all changes because the data is held only in lists in memory. A future version could replace `LibraryService` with a database or JSON repository without changing the general form responsibilities.
