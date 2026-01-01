# Task Manager – ASP.NET Core MVC

A role-based Task Manager web application built using **ASP.NET Core MVC**, **Entity Framework Core**, and **Microsoft Identity**.

## Features
- Authentication (Register / Login / Logout)
- Role-based Authorization:
  - **SuperAdmin**: Full access (Create, View, Edit, Delete all tasks)
  - **Admin**: View all tasks and Edit (No Create, No Delete)
  - **DataEntry**: Create tasks and View only own tasks
- Task CRUD operations
- Generic Repository Pattern
- Clean MVC architecture

## Tech Stack
- ASP.NET Core MVC
- Entity Framework Core
- Microsoft Identity
- SQL Server (LocalDB)

## Roles
These users are automatically assigned roles on application startup:
- SuperAdmin → muhammadibrahim7866663@gmail.com
- Admin → admin@gmail.com
- DataEntry → dataentry@gmail.com

## Setup Instructions
1. Clone the repository
```bash
git clone <repository-url>
