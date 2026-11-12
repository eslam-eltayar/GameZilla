# GameZilla

GameZilla is a .NET 8 CRUD application designed to manage game-related data with a clean and simple web interface. The project demonstrates core Create, Read, Update, and Delete operations using modern .NET technologies.

## Overview

This application is built to help users perform essential game management tasks such as adding new games, viewing records, updating details, and deleting entries. It is a practical example of a full-stack CRUD project using ASP.NET Core and a web-based frontend.

## Features

- Create new game records
- View all games in a list
- Edit existing game information
- Delete game entries
- Search or filter records (if implemented in your project)
- Simple and responsive UI
- Built with .NET 8

## Tech Stack

- C#
- .NET 8
- ASP.NET Core
- HTML
- CSS
- JavaScript
- SQL Server / database-driven storage (if configured)

## Project Structure

```text
GameZilla/
├── Controllers/
├── Models/
├── Views/
├── wwwroot/
├── Data/
├── appsettings.json
├── Program.cs
├── GameZilla.csproj
├── README.md
└── ...
```

> Adjust the folder structure based on your actual project layout.

## Prerequisites

Before running the project, make sure you have installed:

- .NET 8 SDK
- SQL Server (if using a database)
- Visual Studio 2022 or VS Code
- Git

## Getting Started

1. Clone the repository:

```bash
git clone https://github.com/eslam-eltayar/GameZilla.git
cd GameZilla
```

2. Restore dependencies:

```bash
dotnet restore
```

3. Update the database connection string in `appsettings.json` if needed.

4. Run the application:

```bash
dotnet run
```

5. Open the app in your browser at the local URL shown in the terminal.

## Configuration

If the project uses a database, configure your connection string in:

```text
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GameZillaDb;Trusted_Connection=True;"
  }
}
```

## Usage

Use the application to:

- Add a new game
- Update existing game details
- View game records
- Remove records no longer needed

This project is ideal for learning CRUD operations, .NET architecture, and web app development fundamentals.

## License

This project is currently without a specified license. If you plan to reuse or distribute it, please confirm the licensing terms with the repository owner.

## Author

Eslam Eltayar

## Notes

This README is intended as a starting point and can be customized further with screenshots, live demo links, and additional project details as the application grows.
