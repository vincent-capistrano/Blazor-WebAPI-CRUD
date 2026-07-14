# Blazor WebAPI CRUD

A full-stack CRUD application for managing client records, built with **Blazor WebAssembly** on the frontend and an **ASP.NET Core Web API** backend backed by **SQL Server**.

---

## Features

- **Create** new client records via a dedicated form
- **Read** / list all clients with a sortable table view
- **Update** existing client details inline
- **Delete** client records with confirmation
- Unique email enforcement at the database level
- Entity Framework Core migrations for schema management

---

## Tech Stack

| Layer    | Technology                        |
|----------|-----------------------------------|
| Frontend | Blazor WebAssembly (.NET)         |
| Backend  | ASP.NET Core Web API (.NET)       |
| ORM      | Entity Framework Core             |
| Database | SQL Server                        |

---

## Prerequisites

- [.NET SDK 8+](https://dotnet.microsoft.com/download)
- SQL Server (default config targets the `MSI` instance)
- Visual Studio 2022 or VS Code with the C# extension

---

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/vincent-capistrano/Blazor-WebAPI-CRUD.git
cd Blazor-WebAPI-CRUD
```

### 2. Configure the database connection

Open `API/appsettings.json` and update the connection string to point to your SQL Server instance:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=<YOUR_SERVER>;Initial Catalog=test_db;Integrated Security=True;Trust Server Certificate=True"
}
```

### 3. Apply database migrations

```bash
cd API
dotnet ef database update
```

### 4. Run the API

```bash
# From the API folder
dotnet run
```

The API will start on `https://localhost:5001` (or the port shown in your console).

### 5. Run the Blazor app

```bash
# From the BlazorApp folder
cd ../BlazorApp
dotnet run
```

Open your browser to the URL shown in the console (typically `https://localhost:5002`).

---

## Project Structure

```
Blazor-WebAPI-CRUD/
├── API/
│   ├── Controllers/
│   │   └── ClientsController.cs   # REST endpoints for CRUD
│   ├── Models/
│   │   ├── Client.cs              # Client entity
│   │   └── ClientsDto.cs          # Data transfer object
│   ├── Services/                  # Business logic layer
│   ├── Migrations/                # EF Core migrations
│   └── appsettings.json
├── BlazorApp/
│   ├── Pages/
│   │   └── Clients/
│   │       ├── Index.razor        # Client list
│   │       ├── Create.razor       # Add new client
│   │       ├── Edit.razor         # Edit existing client
│   │       └── Delete.razor       # Delete confirmation
│   └── Program.cs
└── WebApp.sln
```

---

## Data Model

### `Client`

| Field       | Type       | Notes                        |
|-------------|------------|------------------------------|
| `Id`        | int        | Primary key (auto-increment) |
| `FirstName` | string     |                              |
| `LastName`  | string     |                              |
| `Email`     | string     | Unique                       |
| `Phone`     | string     |                              |
| `Address`   | string     |                              |
| `Status`    | string     | e.g. Active, Inactive        |
| `CreatedAt` | DateTime   | Set on creation              |

---

## Author

[@vincent-capistrano](https://github.com/vincent-capistrano)

