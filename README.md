# Student Gradebook System

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![WPF](https://img.shields.io/badge/WPF-0C54C2?style=for-the-badge&logo=windows&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=nuget&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL%20Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

A modern WPF desktop application for managing student grades and subjects with a clean, intuitive interface.

## Features

- **Student Management**: Add and track students with their grades
- **Subject Management**: Organize subjects and associate them with students
- **Grade Tracking**: Record and display student grades for different subjects
- **Average Calculation**: Calculate and display the average grade across all students
- **Many-to-Many Relationship**: Students can be enrolled in multiple subjects
- **Modern UI**: Clean, professional interface with rounded corners and shadow effects

## Technologies Used

- **C# / .NET**: Core programming language and framework
- **WPF (Windows Presentation Foundation)**: Desktop UI framework
- **Entity Framework Core 8.0**: ORM for database operations
- **SQL Server**: Database management system
- **XAML**: UI markup language

## Prerequisites

Before running this application, ensure you have:

- Visual Studio 2022 or later
- .NET 8.0 SDK or later
- SQL Server (Express or full version)
- Entity Framework Core 8.0

## Database Setup

The application uses SQL Server with the following connection string configuration:

```
Server: DESKTOP-2008HFE\SQLEXPRESS
Database: StudentDB
Authentication: Integrated Security
```

### Database Schema

The application creates three tables:

1. **Students**
   - Id (int, Primary Key, Identity)
   - Name (nvarchar(50), Required)
   - Grade (int, Required)

2. **Subjects**
   - Id (int, Primary Key, Identity)
   - Name (nvarchar(50), Required)

3. **StudentSubject** (Junction Table)
   - StudentsId (int, Foreign Key)
   - SubjectsId (int, Foreign Key)

## Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/student-gradebook.git
```

2. Open the solution in Visual Studio

3. Update the connection string in `StudentDB.cs` to match your SQL Server instance:
```csharp
optionsBuilder.UseSqlServer("Data Source=YOUR_SERVER;Initial Catalog=StudentDB;Integrated Security=True;Trust Server Certificate=True");
```

4. Open Package Manager Console and run:
```bash
Update-Database
```

5. Build and run the application

## Usage

### Adding a Student with Subject and Grade

1. Enter the student name in the "Student Name" field
2. Enter the subject name in the "Subject" field
3. Enter the grade as a number in the "Grade" field
4. Click the "Add" button

### Calculating Average Grade

- Click the "حساب المعدل" (Calculate Average) button to display the average grade across all students

### Viewing Data

- The DataGrid displays all students with their subjects and grades
- The grid features alternating row colors for better readability

## Project Structure

```
Student_Gradebook/
├── Model/
│   ├── Student.cs          # Student entity model
│   ├── Subject.cs          # Subject entity model
│   └── StudentsDB.cs       # Database context
├── Migrations/
│   └── ...                 # EF Core migrations
├── MainWindow.xaml         # UI layout
└── MainWindow.xaml.cs      # UI logic and event handlers
```

## Key Features Details

### Data Validation

- Checks for empty student names
- Checks for empty subject names
- Validates grade input as numeric
- Prevents duplicate student-subject associations

### UI Design

- Modern, clean interface with rounded corners
- Shadow effects for depth
- Hover effects on buttons and rows
- Color-coded headers
- Responsive layout

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## License

This project is open source and available under the [MIT License](LICENSE).

## Contact

For questions or suggestions, please open an issue on GitHub.

---

**Note**: This application is designed for educational purposes and demonstrates WPF, Entity Framework Core, and SQL Server integration.
