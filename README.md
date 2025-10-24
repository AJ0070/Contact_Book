# Contact Management App

A simple, lightweight contact management application built with ASP.NET Core that allows you to store, manage, and organize your contacts without requiring a database setup.

## Features

- **Full CRUD Operations**: Create, Read, Update, and Delete contacts
- **Search & Filter**: Search contacts by name, email, or phone number
- **CSV Export**: Export all contacts to CSV format
- **Data Validation**: Server-side validation using Data Annotations
- **Responsive UI**: Clean, Bootstrap-styled interface
- **File-Based Storage**: JSON file storage (no database required)
- **Dual Views**: Simple list view and full management interface
- **Mobile Friendly**: Responsive design that works on all devices

## Technology Stack

- **Framework**: ASP.NET Core 9.0 MVC
- **Frontend**: Bootstrap 5, HTML5, CSS3
- **Backend**: C# 12.0
- **Storage**: JSON File (No database required!)
- **Validation**: Data Annotations
- **IDE**: Visual Studio 2022 / Visual Studio Code

## Project Structure

```
ContactManagement/
├── Controllers/           # Web API controllers
│   ├── ContactsController.cs    # Contact CRUD operations
│   └── HomeController.cs        # Home page controller
├── Models/               # Data models and business logic
│   ├── Contact.cs              # Contact entity with validation
│   ├── ContactRepository.cs    # JSON file operations
│   └── ContactDbContext.cs     # Repository wrapper
├── Views/                # Razor views
│   ├── Contacts/               # Contact-related views
│   │   ├── Index.cshtml        # Full management interface
│   │   ├── List.cshtml         # Simple contact list
│   │   ├── Create.cshtml       # Add new contact
│   │   ├── Edit.cshtml         # Edit contact
│   │   ├── Delete.cshtml       # Delete confirmation
│   │   └── Details.cshtml      # Contact details
│   ├── Shared/                 # Shared layout and components
│   └── Home/                   # Home page views
├── wwwroot/              # Static files (CSS, JS, images)
├── Properties/           # Project properties
├── Data/                 # Auto-created for JSON storage
└── appsettings.json      # Configuration settings
```

## Installation

### Prerequisites

- **.NET 9.0 SDK** or later
- **Windows, macOS, or Linux** operating system
- **Visual Studio 2022** (recommended) or **Visual Studio Code**

### Steps

1. **Clone or Download** the project files
2. **Navigate** to the project directory:
   ```bash
   cd ContactManagement
   ```
3. **Restore** dependencies (if needed):
   ```bash
   dotnet restore
   ```
4. **Build** the project:
   ```bash
   dotnet build
   ```

**No additional installation required!** The app uses JSON file storage, so no database setup is needed.

## How to Run

### Option 1: Using .NET CLI
```bash
# Navigate to project directory
cd ContactManagement

# Run the application
dotnet run
```

### Option 2: Using Visual Studio
1. Open `ContactManagement.csproj` in Visual Studio
2. Press `F5` or click "Run" button
3. The app will open in your default browser

### Option 3: Using Visual Studio Code
1. Open the project folder in VS Code
2. Press `F5` or run from terminal: `dotnet run`

## Accessing the Application

Once running, open your browser and navigate to:
```
http://localhost:5234
```

The home page will automatically redirect you to the contacts section.

## Usage

### Navigation Views

**1. Simple Contact List** (Default Navigation)
- Click "Contacts" in the navigation bar
- Shows clean list of all saved contacts
- Use "Full Management" button for advanced features

**2. Full Management Interface**
- Click "Full Management" from simple list
- Access all features: search, export, create new contacts
- Use "Simple List" button to return to clean view

### Managing Contacts

#### Creating a Contact
1. Click "Create New Contact" button
2. Fill in the required fields:
   - First Name
   - Last Name
   - Email Address
   - Phone Number
   - Address
3. Click "Create" to save

#### Searching Contacts
1. Use the search bar in the full management interface
2. Search by: name, email, or phone number
3. Click "Clear" to reset search

#### Editing a Contact
1. Click "Edit" button next to any contact
2. Modify the contact information
3. Click "Save" to update

#### Deleting a Contact
1. Click "Delete" button next to any contact
2. Confirm deletion in the confirmation dialog
3. Contact will be permanently removed

#### Exporting Contacts
1. Click "Export to CSV" button
2. Download will start automatically
3. Open the CSV file in Excel or any spreadsheet application

### Data Storage

- **Storage Location**: `Data/contacts.json`
- **Format**: JSON (human-readable)
- **Auto-Creation**: File created automatically on first contact
- **Backup**: Simply copy the `Data` folder to backup contacts

## Configuration

The application uses minimal configuration stored in `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

No database connection strings or complex configuration required!

## Contributing

1. Fork the repository
2. Create your feature branch: `git checkout -b feature/amazing-feature`
3. Commit your changes: `git commit -m 'Add amazing feature'`
4. Push to the branch: `git push origin feature/amazing-feature`
5. Open a Pull Request

## License

This project is open source and available under the [MIT License](LICENSE).

## Troubleshooting

### Common Issues

**1. Port Already in Use**
```bash
# Kill existing processes on port 5234
netstat -ano | findstr :5234
taskkill /PID <PID> /F
```

**2. File Access Issues**
- Ensure no other instances of the app are running
- Check file permissions in the project directory

**3. No Contacts Showing**
- Check if `Data/contacts.json` exists and contains valid JSON
- Verify contacts were created successfully

### Getting Help

- Check the browser console for JavaScript errors
- Review application logs in the terminal
- Ensure .NET 9.0 SDK is properly installed

## What's Unique

- **Zero Database Setup** - No SQL Server, MySQL, or database installation required
- **File-Based Storage** - Simple JSON files for data persistence
- **Lightweight** - Minimal dependencies and configuration
- **Cross-Platform** - Runs on Windows, macOS, and Linux
- **Developer Friendly** - Clean code structure and comprehensive documentation

---

**Made using ASP.NET Core**
