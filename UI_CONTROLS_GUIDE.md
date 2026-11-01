# UI Controls and Properties Guide

This guide explains the Windows Forms controls used in the Library Management System and why each property is used. The visible layout is stored in each form's `.Designer.cs` file, while actions and service calls are stored in the form's `.cs` file.

## 1. Common layout properties

### `Dock`

`Dock` attaches a control to one side of its parent or makes it fill the available space.

Examples in this project:

- `DockStyle.Top` keeps the title and navigation area at the top.
- `DockStyle.Fill` makes the workspace, grids, editor panels, and summary layouts use the remaining space.

`DockStyle.Fill` is important because it makes controls grow when the main window is maximized.

### `Anchor`

`Anchor` keeps a control attached to selected edges when its parent is resized.

For example:

- A grid can be anchored to the top, bottom, and left.
- An editor panel can be anchored to the top and right.

The current CRUD pages mainly use `TableLayoutPanel` and `DockStyle.Fill`, which is more predictable than manually positioning controls at fixed coordinates.

### `AutoScroll`

`AutoScroll = true` adds scrollbars when the content is larger than the available area. It is used on the pages that contain grids and editor panels so the controls do not disappear on a smaller window.

### `MinimumSize`

`MinimumSize` prevents a form from becoming too small to use. It helps keep labels, fields, buttons, and tables readable.

### `AutoScaleMode`

`AutoScaleMode = Font` lets WinForms adjust control sizes when the system font or display scaling changes.

## 2. MainForm

`MainForm` is the main shell. It does not contain the business logic for books or members. Its job is navigation and hosting.

### Header `Label`

Control: `headerLabel`

Important properties:

- `Dock = DockStyle.Top` - keeps the header at the top.
- `Height = 48` - gives the header a consistent height.
- `BackColor` - creates the blue application header.
- `ForeColor = Color.White` - makes the text readable.
- `Padding` - keeps the text away from the edge.
- `Font` - makes the application title prominent.

The header also displays the logged-in role, such as `Administrator` or `Librarian`.

### `TabControl`

Control: `tabs`

Important properties:

- `Dock = DockStyle.Top` - keeps tabs above the workspace.
- `Alignment = TabAlignment.Top` - keeps the tabs at the top.
- `Multiline = false` - keeps the navigation on one row.
- `SizeMode = TabSizeMode.Normal` - lets WinForms size the tab headers normally.
- `Padding` - gives tab captions comfortable spacing.
- `SelectedIndexChanged` - loads the selected page into the workspace.

Each `TabPage` has a form stored in its `Tag` property. When the selected tab changes, `MainForm` reads that form and displays it.

### `GroupBox`

Control: `pageGroup`

Important properties:

- `Dock = DockStyle.Fill` - uses all space below the header and tabs.
- `Padding` - gives hosted pages space inside the border.
- `Text = "Workspace"` - identifies the content area.

The child forms are hosted inside this GroupBox using:

- `TopLevel = false`
- `FormBorderStyle = None`
- `Dock = DockStyle.Fill`

This means the application uses one main window instead of opening many separate windows.

## 3. LoginForm

The Login page is made from simple input controls.

### Title and instruction `Label` controls

The labels display the application name, instructions, and login messages.

Useful properties:

- `AutoSize = true` - sizes the label to its text.
- `Font` - creates a larger title.
- `ForeColor` - changes the message color when credentials are invalid.
- `Location` - positions small labels inside the login layout.

### Login `GroupBox`

Control: `loginGroup`

The GroupBox keeps the username, password, and sign-in button together under the heading `Account`.

This makes the purpose of the controls clear and gives the login form a visual boundary.

### `TextBox`

Controls:

- `usernameTextBox`
- `passwordTextBox`

Important properties:

- `Size` - controls the input width.
- `PasswordChar = '*'` - hides the password characters.
- `Location` - places each input beside its label.

### `Button`

Control: `signInButton`

Important properties:

- `Text = "Sign in"` - describes the action.
- `Click` - calls `SignInButton_Click`.
- `BackColor` and `ForeColor` - provide visual emphasis.
- `FlatStyle` - gives the button a simple appearance.

`AcceptButton = signInButton` also allows the user to press Enter to sign in.

## 4. HomeForm

The Home page uses a responsive `TableLayoutPanel` instead of fixed positions.

### Main `TableLayoutPanel`

Control: `contentLayout`

Important properties:

- `Dock = DockStyle.Fill` - fills the Home page.
- `ColumnCount = 1` - creates one full-width column.
- `RowCount = 3` - creates rows for the title, description, and summary.
- `ColumnStyles` and `RowStyles` - control how available space is shared.
- `Padding` - keeps content away from the page edges.
- `AutoScroll = true` - supports small windows.

The third row uses percentage sizing, so the summary area receives the remaining height.

### Summary `GroupBox`

Control: `summaryGroup`

The GroupBox is docked to fill the summary row and is titled `Today at a glance`.

### Summary `TableLayoutPanel`

Control: `summaryTable`

It has three equal percentage columns:

- Books
- Members
- On loan

Each summary label uses:

- `Dock = DockStyle.Fill`
- `TextAlign = ContentAlignment.MiddleCenter`
- `AutoSize = false`

This keeps all three values centered and evenly spaced when the window changes size.

## 5. BooksForm

BooksForm contains a book table and a CRUD editor.

### Management `TableLayoutPanel`

Control: `managementLayout`

This is the main layout container for the page.

- Column 1 uses about 64 percent of the width for the table.
- Column 2 uses about 36 percent for the editor.
- `Dock = DockStyle.Fill` makes the layout resize with the page.
- `Padding` creates a clean outer margin.

The table and editor are added to this layout instead of being placed far apart with fixed coordinates.

### `DataGridView`

Control: `booksGrid`

It displays:

- ID
- Title
- Author
- Status

Important properties:

- `Dock = DockStyle.Fill` - fills the first layout column.
- `ReadOnly = true` - users edit through the editor fields.
- `AllowUserToAddRows = false` - prevents an accidental blank row.
- `AutoSizeColumnsMode = Fill` - shares the available table width between columns.
- `SelectionMode = FullRowSelect` - selects a complete book record.
- `BackgroundColor` - keeps the table consistent with the rest of the page.
- `SelectionChanged` - loads the selected book into the editor.

### Book details `GroupBox`

Control: `editorGroup`

The GroupBox contains the title and author fields and the CRUD buttons. It uses `Dock = DockStyle.Fill` in the second layout column.

### CRUD `TextBox` controls

Controls:

- `titleTextBox`
- `authorTextBox`

These are used by the Add and Edit actions.

### CRUD `Button` controls

Controls:

- `addButton`
- `editButton`
- `deleteButton`

Each button has a `Click` event that calls the matching service operation.

## 6. MembersForm

MembersForm uses the same layout pattern as BooksForm.

### `DataGridView`

Control: `membersGrid`

It displays:

- ID
- Name
- Phone
- Books out

The grid uses `DockStyle.Fill`, full-row selection, read-only display, and automatic column filling.

### Member details `GroupBox`

Control: `editorGroup`

It contains:

- `nameTextBox`
- `phoneTextBox`
- Add button
- Edit button
- Delete button

The editor occupies the second column of `managementLayout`, so it stays beside the member table instead of being positioned at an unrelated fixed location.

## 7. StaffForm

StaffForm is available only to administrators and uses the same two-column layout.

### Staff `DataGridView`

Control: `staffGrid`

It displays:

- ID
- Username
- Role

Important properties are the same as the Books and Members grids:

- Read-only display.
- Full-row selection.
- Fill column sizing.
- Docked inside the first layout column.

### Staff details `GroupBox`

Control: `editorGroup`

It contains:

- Username TextBox.
- Password TextBox.
- Role ComboBox.
- Add, Edit, and Delete buttons.

### `ComboBox`

Control: `roleComboBox`

Important properties:

- `DropDownStyle = DropDownList` - only allows the defined roles.
- `Items` - contains `Administrator` and `Librarian`.
- `SelectedIndex` - selects a default role.

## 8. IssueReturnForm

This page uses a form GroupBox for actions and a DataGridView for loan history.

### Action `GroupBox`

Control: `actionGroup`

It groups the member selector, book selector, issue button, return button, and status message.

### Selection `ComboBox` controls

Controls:

- `memberComboBox`
- `bookComboBox`

Important properties:

- `DropDownStyle = DropDownList` - prevents invalid typed values.
- `Items` - filled from the shared service.
- `SelectedIndex` - chooses the first available item when possible.

### Action `Button` controls

- `issueButton` creates a loan and marks the book unavailable.
- `returnButton` completes the selected loan and makes the book available again.

The `Click` events call the service layer rather than changing data directly in the designer.

### Loan history `DataGridView`

Control: `loansGrid`

It displays:

- Loan ID
- Book
- Member
- Issued date
- Returned date or Active status

It is docked and anchored to use the available width and height below the action area.

## 9. ReportsForm

ReportsForm uses a GroupBox and a four-column TableLayoutPanel.

### Report `GroupBox`

Control: `reportGroup`

It is docked to fill the page below the title and has padding around the summary content.

### Summary `TableLayoutPanel`

Control: `summaryTable`

It has four equal percentage columns:

1. Total books
2. Books currently on loan
3. Registered members
4. Overdue books

Each report label is docked to fill its cell and centered with `TextAlign`. This avoids fixed coordinates and keeps the reports balanced on large and small windows.

## 10. Why the layout uses these controls

- `GroupBox` groups controls with the same purpose.
- `TableLayoutPanel` creates consistent rows and columns.
- `DataGridView` displays lists of records.
- `TextBox` accepts short text input.
- `ComboBox` gives the user a controlled choice.
- `Button` starts an action.
- `Label` displays titles, instructions, values, and messages.
- `TabControl` organizes the main responsibilities into pages.
- `Dock` makes controls fill available areas.
- `Anchor` keeps controls attached to the correct edges.
- `AutoScroll` prevents content from being hidden on smaller windows.

Together, these controls make the application easier to resize, understand, and maintain in the Visual Studio Designer.
