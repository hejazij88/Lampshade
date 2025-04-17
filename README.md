🛒 Lampshade Shop
A sample e-commerce web application built using ASP.NET Core MVC, implementing best practices in Domain-Driven Design (DDD), Repository Pattern, and Clean Architecture. The project simulates an online lampshade store, and is ideal for learning enterprise-level software architecture and application layering in .NET.

🔧 Technologies Used
.NET 6 / .NET Core

ASP.NET Core MVC

Entity Framework Core

SQL Server

Razor Pages

Dependency Injection

Authentication & Authorization

Unit of Work & Repository Patterns

Domain-Driven Design (DDD) principles

Bootstrap (UI styling)

📁 Project Structure
The solution is organized into multiple projects to follow clean architecture:

scss
Copy
Edit
Lampshade
│
├── BlogManagement (Domain, Application, Infrastructure, Presentation)
├── CommentManagement
├── DiscountManagement
├── InventoryManagement
├── ShopManagement
├── AccountManagement
├── Framework (Shared utilities and base classes)
├── Query (Read-only services using DTOs)
├── ServiceHost (Main ASP.NET Core project)
Each feature (Blog, Comment, Discount, Inventory, Shop, Account) is modularized into layers:

*.Domain: Entity models and domain logic.

*.Application: Application services and use cases.

*.Infrastructure: Data access implementations using EF Core.

*.Configuration: Dependency injection setup.

*.Contracts: Interfaces and DTOs.

🚀 Getting Started
Clone the repository:

bash
Copy
Edit
git clone https://github.com/hejazij88/Lampshade.git
cd Lampshade
Set up your database:

Update the connection string in appsettings.json under ServiceHost.

Apply EF Core migrations or run the provided SQL script if available.

Run the application:

Open Lampshade.sln in Visual Studio.

Set ServiceHost as the startup project.

Press F5 or run the project.

Log in to admin panel:

Default credentials may be seeded or configurable (check AccountManagement seed data).

📚 Features
Modular design following DDD principles

Clean separation of concerns and layered architecture

Authentication/Authorization for admin panel

Admin interfaces for managing:

Products & categories

Inventory

Discounts

Blog & comments

User accounts

Front-end shop query logic with separated read models

📷 Screenshots
(You can add screenshots of the Admin Panel and Storefront UI here)

🙌 Credits
This project is inspired by and based on Moshfegh Hejazi’s DDD e-commerce training course (in Persian). It's an educational project to demonstrate professional .NET architecture patterns.
