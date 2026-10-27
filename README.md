# Library Management System – Phase 1 (Desktop Application)

C# WinForms, .NET 8. Event-driven UI with data kept **in memory only** (no database yet).

## Run
1. Install Visual Studio 2022 with the ".NET desktop development" workload (or the .NET 8 SDK on Windows).
2. Open `LibraryApp.csproj` in Visual Studio and press **F5**.
   Or from a terminal on Windows: `dotnet run`

Demo logins: `admin / admin123` and `librarian / lib123`.
Sample books, members and loans are loaded at start so every screen has data.

## Phase 1 requirements → where they are

| Requirement | Where |
| --- | --- |
| Event-driven UI (buttons, forms, navigation) | `Forms/` – every action is a Click / TextChanged / SelectedIndexChanged / KeyPress handler; `MainForm` menu, toolbar and shortcuts (Ctrl+B, Ctrl+M, Ctrl+I, Ctrl+R) |
| Validation | `BooksForm`, `MembersForm`, `LoginForm` – ErrorProvider icons, required fields, ISBN / email / phone checks, digits-only ISBN box |
| Local memory storage | `Services/LibraryService.cs` – `List<Book>`, `List<Member>`, `List<Loan>` |
| Basic business logic | `LibraryService` – max 3 loans, 14-day loan, 1 renewal, 2 Birr/day fine, no issue with overdue books or unpaid fines, no delete when active loans |
| Clean UI and structure | `Models/`, `Services/`, `Forms/` separation; shared look in `Forms/Ui.cs` |
| Multi-form navigation, ListView, search/filter, edit/delete, menu/toolbar, status messages, simple report | Login → Main → Home / Books / Members / Issue-Return / Reports |

## Structure
```
Program.cs              entry point (login loop)
Models/Models.cs        Book, Member, Loan, AppUser, Result
Services/LibraryService in-memory data + business rules (replaced by API calls in Phase 2)
Forms/                  LoginForm, MainForm, HomeForm, BooksForm, MembersForm,
                        IssueReturnForm, ReportsForm, Ui (helpers + ChildForm base)
```

## Phase 2 note
Forms only talk to `LibraryService`. In Phase 2 keep the same method names and change their bodies to call the REST API, so the screens do not need to change.
