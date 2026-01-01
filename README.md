# Task Manager – ASP.NET Core MVC

A role-based **Task Manager web application** built using **ASP.NET Core MVC**, **Entity Framework Core**, and **Microsoft Identity**.  
The project demonstrates **authentication**, **authorization**, and **clean architecture** using the **Generic Repository Pattern**.

---

## 🚀 Features

- User Authentication (Register / Login / Logout)
- Role-Based Authorization with three roles:
  - **SuperAdmin**
    - Full access (Create, View, Edit, Delete all tasks)
  - **Admin**
    - View all tasks
    - Edit any task
    - ❌ Cannot create or delete tasks
  - **DataEntry**
    - Create new tasks
    - View **only own tasks**
    - ❌ Cannot edit or delete tasks
- Task CRUD Operations
- Secure access using Microsoft Identity
- Generic Repository Pattern implementation
- Clean MVC architecture
- SQL Server (LocalDB) support

---

## 🧠 Roles & Permissions Summary

| Role        | Create | View All | View Own | Edit | Delete |
|------------|--------|----------|----------|------|--------|
| SuperAdmin | ✅     | ✅       | ✅       | ✅   | ✅     |
| Admin      | ❌     | ✅       | ✅       | ✅   | ❌     |
| DataEntry  | ✅     | ❌       | ✅       | ❌   | ❌     |

---

## 🛠 Tech Stack

- ASP.NET Core MVC
- Entity Framework Core
- Microsoft Identity
- SQL Server (LocalDB)
- Bootstrap
- C#

---

## 📁 Project Structure (YAML)

TaskManager-ASP.NET-Core-MVC:
  Microsoft Auth:
    Controllers:
      - HomeController.cs
      - TaskItemsController.cs

    Data:
      - AppDbContext.cs

    Migrations:
      - Initial migrations
      - Identity migrations
      - CreatedBy column migrations

    Models:
      - ApplicationUser.cs
      - TaskItem.cs
      - ErrorViewModel.cs

    Repositories:
      - IGenericRepository.cs
      - GenericRepository.cs

    Views:
      Home:
        - Index.cshtml
        - Privacy.cshtml
      TaskItems:
        - Index.cshtml
        - Create.cshtml
        - Edit.cshtml
        - Delete.cshtml
        - Details.cshtml
      Shared:
        - _Layout.cshtml
        - _LoginPartial.cshtml
        - _ValidationScriptsPartial.cshtml

    wwwroot:
      css:
      js:
      lib:
        bootstrap:
        jquery:
        jquery-validation:

    - Program.cs
    - README.md
    - .gitignore
    - appsettings.json.example
    - Microsoft Auth.csproj
    - Microsoft Auth.sln
