
# CampusTrack — Student Management System

CampusTrack is a student management application developed using
C# and ASP.NET Core Web API.

It allows users to register, view, update, and delete student
records through a web dashboard.

## Features

- Student registration
- View student records
- Update student information
- Delete student records
- Input validation
- RESTful API endpoints
- Persistent SQLite database
- Swagger API documentation
- Web-based dashboard

## Tech Stack

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- HTML
- CSS
- JavaScript
- Swagger / OpenAPI
- Visual Studio Code

## Project Structure

CampusTrack.Api/
├── Models/
│   └── Student.cs
├── Data/
│   └── StudentDbContext.cs
├── wwwroot/
│   └── index.html
├── Properties/
├── Program.cs
└── CampusTrack.Api.csproj

## Getting Started

### Prerequisites

- .NET SDK
- Visual Studio Code

### Run the application

1. Clone the repository.
2. Open the project folder in VS Code.
3. Open the integrated terminal.
4. Run:

dotnet restore
dotnet run

5. Open the local URL displayed in the terminal.

### API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | /api/students | Get all students |
| GET | /api/students/{id} | Get student by ID |
| POST | /api/students | Register student |
| PUT | /api/students/{id} | Update student |
| DELETE | /api/students/{id} | Delete student |

## Learning Outcomes

- Building REST APIs using ASP.NET Core
- Implementing CRUD operations
- Working with Entity Framework Core
- Integrating SQLite
- Validating user input
- Connecting a frontend to backend APIs

## Disclaimer

This project was developed for academic learning
and practical software development experience.
