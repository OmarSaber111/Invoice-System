# Back-End for Invoice Project (ASP.NET Core Web API)

This repository contains the back-end of the Invoice application, built with **ASP.NET Core Web API**. It provides RESTful APIs for managing users, sellers, buyers, products, invoices, and permissions.

## Prerequisites

Before running the project, ensure you have the following installed:

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
* [Visual Studio 2022+](https://visualstudio.microsoft.com/) or [Visual Studio Code](https://code.visualstudio.com/)

> ✅ Entity Framework Core is used for database interactions (Code First / Database First depending on setup).

---

## Getting Started

### 1. Clone the Repository

Clone the entire repository (including the front-end folder):

```bash
git clone https://github.com/your-username/your-repo-name.git
```

### 2. Navigate to the Back-End Folder

```bash
cd your-repo-name/back-end
```

### 3. Configure the Database Connection

Update your `appsettings.json` with your SQL Server connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=InvoiceDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

> You can also use SQL authentication:
> `"Server=YOUR_SERVER_NAME;Database=InvoiceDB;User Id=sa;Password=your_password;"`

### 4. Apply Migrations and Seed the Database

If using **Code First**, apply migrations with the following command:

```bash
dotnet ef database update
```

Ensure `Microsoft.EntityFrameworkCore.Tools` is installed.

If using **Database First**, make sure the `.edmx` or `DbContext` is generated accordingly.

---

### 5. Run the Project

Run the Web API using the following command:

```bash
dotnet run
```

Or use Visual Studio's **Run** or **F5**.

---

## API Documentation – Swagger UI

Once the project is running, open your browser and go to:

```
http://localhost:5000/swagger/index.html
```

Or if hosted:

```
http://invoice.somee.com/swagger/index.html
```

This Swagger UI provides full access to test and explore available endpoints.

---

## Folder Structure

```
Invoice.API/                - Main Web API project
├── Controllers/            - API Controllers
├── DTOs/                   - Data Transfer Objects
├── Models/                 - Entity Models
├── Data/                   - DbContext and Seeders
├── Services/               - Business logic layer
├── Repositories/           - Repository layer for data access
├── Helpers/                - JWT & Utilities
├── appsettings.json        - Configuration
```

---

## Main Features

* **JWT Authentication** (Admin / Buyer / Seller)
* **Role-based Authorization**
* **CRUD operations** for:

  * Users
  * Sellers & Buyers
  * Products (with image support)
  * Invoices
  * Categories
* **Group & Permission Management**
* **Secure password hashing**
* **Extensible architecture** using Repository & Service layers
* **DTO Mapping** using AutoMapper

---

## Integration with Front-End

To connect with the Angular front-end:

1. Ensure CORS is enabled in `Program.cs`:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});
```

2. Use the same API base URL in Angular's `environment.ts`:

```ts
apiUrl: 'http://invoice.somee.com/api'
```

---

## Deployment

For production deployment:

* Host API on IIS / Azure / Somee.com
* Update environment variables and `environment.prod.ts` on Angular side
* Ensure HTTPS is enabled and CORS is properly configured

---

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

---

## License

[MIT](https://choosealicense.com/licenses/mit/)

---
