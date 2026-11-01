# Library Management System

A small Windows Forms library management sample built with .NET 10. The application uses a simple model and service layer with in-memory data only.

## Run

1. Open `LibraryManagementSystem.slnx` in Visual Studio 2026.
2. Build and run the `LibraryManagementSystem` project.
3. Sign in with one of the demo accounts below.

## Demo accounts

| Role | Username | Password |
| --- | --- | --- |
| Administrator | `admin` | `admin123` |
| Librarian | `librarian` | `library123` |

## Responsibilities

- **Librarian**: manage books and members, and issue or return books.
- **Administrator**: all librarian actions plus staff account management and reports.

Books, members, and staff pages use simple Add, Edit, and Delete controls. Select a row to edit or delete it.

## Loan workflow

1. Open `Issue / Return`.
2. Select a member and an available book.
3. Click `Issue book`.
4. Select the loan in the history grid and click `Return selected` when it is returned.

A book with an active loan cannot be deleted. A member with an active loan cannot be deleted. The last administrator account cannot be deleted.

## Layout

The main window has navigation tabs at the top. Each page is displayed inside the `Workspace` group box, so the application stays in one window instead of opening many separate forms.

## Important note

Books, members, loans, and staff accounts are created in `LibraryService` when the application starts. Changes are kept in memory until the application closes. Nothing is written to a database or file.

## Full system guide

See [SYSTEM_GUIDE.md](SYSTEM_GUIDE.md) for a form-by-form explanation of the roles, tabs, GroupBox layout, models, service layer, and lending rules.

See [UI_CONTROLS_GUIDE.md](UI_CONTROLS_GUIDE.md) for an explanation of the toolbox controls and layout properties used on each page.
