# Internship Tracker System

A Windows desktop application that manages the whole internship process between students, companies and university supervisors. Students search and apply for internships, company HR staff post positions and decide on applications, and supervisors follow each intern's reports and write evaluations.

Built as a group project (Group 10) for an Object-Oriented Programming (IOOP) assignment at Asia Pacific University (APU), with **C#, Windows Forms (.NET 8) and SQL Server**. The design shows the main OOP ideas: classes and objects, encapsulation (model classes), inheritance and a layered structure.

## Features

### Students
- Search internship positions and filter by location and company
- View position details and apply with a cover letter
- Track applications by status, and cancel an application
- See a dashboard with personal statistics and active internships
- Submit progress reports, and resubmit a report after feedback
- View evaluations written by the supervisor
- Manage the student profile

### Company HR
- Create, edit, view, open, close and delete internship positions
- Review applications, then accept or reject them with remarks
- Track the interns of the company, with search and status filters
- See a dashboard with hiring statistics
- Manage the HR and company profile

### Supervisors
- See assigned interns, including ongoing internships and those that still need an evaluation
- Read student reports and update their status
- Create and update evaluations with performance, punctuality and communication scores, an overall score, comments and recommendations
- Receive notifications, with unread counts and mark-as-read
- Manage the supervisor profile

## Tech stack

| Area | Technology |
|---|---|
| Language | C# |
| UI | Windows Forms on .NET 8 (`net8.0-windows`) |
| Database | Microsoft SQL Server, accessed with `System.Data.SqlClient` |
| IDE | Visual Studio 2022 |

## Architecture

The code is split into four layers:

- **Forms/**: Windows Forms screens, grouped by role (`CompanyHR`, `Student`, `Supervisor`) plus the shared login form
- **Class/**: business logic for each role (`StudentClass`, `CompanyHRClass`, `SupervisorClass`) and `UserClass` for login
- **Model/**: data models passed between the forms and the logic
- **Data/**: `DatabaseHelper`, the single place that talks to SQL Server

Every query goes through `DatabaseHelper` with SQL parameters, and database errors are logged to `ErrorLog.txt`. After login, the user's role decides which main screen opens.

### Database

The sample database has 11 tables: `Users`, `Students`, `Supervisors`, `CompanyHR`, `Companies`, `InternshipPositions`, `Applications`, `Internships`, `StudentReports`, `SupervisorEvaluations` and `Notifications`. The ERD is not included yet.

## Project structure

```
.
├── InternshipTrackerSystem.sln
├── InternshipTraker_Backup.sql          Database script with sample data
└── InternshipTrackerSystem/
    ├── Forms/
    │   ├── User/                        Login
    │   ├── Student/
    │   ├── CompanyHR/
    │   └── Supervisor/
    ├── Class/                           Business logic per role
    ├── Model/
    ├── Data/DatabaseHelper.cs
    └── Program.cs
```

## Getting started

### Prerequisites
- Windows
- Visual Studio 2022 with the **.NET desktop development** workload
- SQL Server (a local default instance) and SQL Server Management Studio (SSMS)

### 1. Clone the repository
```bash
git clone https://github.com/xiulailai/InternshipTrackerSystem.git
```

### 2. Create the database
1. Open `InternshipTraker_Backup.sql` in SSMS, connected to `localhost`.
2. Run it (F5). It creates the `InternshipTracker` database, all tables and the sample data.

> The script creates the database files under `C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\`, which is the default for SQL Server 2022. If you use another version, instance or LocalDB, edit those two file paths in the `CREATE DATABASE` statement at the top, or create an empty `InternshipTracker` database yourself and run the script from the line `USE [InternshipTracker]` onwards.

### 3. Run the application
Open `InternshipTrackerSystem.sln` in Visual Studio and press **F5**.

By default the app connects to `localhost` with Windows authentication. To use another server, add a connection string named `InternshipTrackerDB` to an `App.config` file in the project:

```xml
<configuration>
  <connectionStrings>
    <add name="InternshipTrackerDB"
         connectionString="Server=YOUR_SERVER;Database=InternshipTracker;Integrated Security=True;TrustServerCertificate=True"
         providerName="System.Data.SqlClient"/>
  </connectionStrings>
</configuration>
```

## Demo accounts

All accounts use the password `Password123!`, and you log in with the **email**. All data is fictional.

| Role | Email |
|---|---|
| Student | `john.doe@student.edu` |
| Student | `jane.smith@student.edu` |
| Company HR | `robert@techcorp.com` |
| Company HR | `lisa@innovatesoft.com` |
| Supervisor | `anderson@university.edu` |
| Supervisor | `wilson@university.edu` |

The sample data has 13 users, 5 students, 3 supervisors, 4 HR staff, 5 companies, 6 positions, 8 applications, 5 internships, 6 reports and 3 evaluations.

## Known limitations

- **Demo-level login.** Passwords are stored and compared as plain text. Hash them (for example with BCrypt) before any real use.
- **Database script paths.** The script assumes the default SQL Server 2022 data folder (see above).

## Team

Group 10, Object-Oriented Programming (IOOP) assignment, Asia Pacific University (APU).

| Role area | Members |
|---|---|
| Company HR | [@2FoR1](https://github.com/2FoR1), [@Xylore9](https://github.com/Xylore9) |
| Supervisor | [@xiulailai](https://github.com/xiulailai) |
| Student | [@weishewng](https://github.com/weishewng), [@xiulailai](https://github.com/xiulailai), [@Bymys1de](https://github.com/Bymys1de) |

## License

Released under the [MIT License](LICENSE). Copyright (c) 2026 automaticicemaker Contributors and APU.
