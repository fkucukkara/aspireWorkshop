# Aspire Playground

## Overview
This project is a **.NET 9 API** built as an **Aspire Playground**, showcasing best practices for implementing:

- **Generic Repository Pattern**
- **Unit of Work Pattern**
- **SQL Server** integration with **Entity Framework Core**

The project serves as a learning and experimentation ground for advanced .NET development concepts, including clean architecture, reusable data access patterns, and efficient database transactions.

## Features
- **Aspire Framework**: Provides a robust foundation for building APIs.
- **Generic Repository**: A flexible data access abstraction for performing common CRUD operations.
- **Unit of Work**: Manages transactional consistency across multiple operations.
- **Entity Framework Core**: Simplifies interaction with SQL Server.
- **.NET 9 API**: Leverages the latest features and improvements in .NET 9.

## Description
The **Generic Repository** encapsulates common database operations like adding, updating, deleting, and retrieving entities. It promotes reusability and separation of concerns by abstracting data access logic from business logic.

The **Unit of Work** ensures that all database changes made during a single operation are committed or rolled back as a unit, maintaining data integrity.

### Key Components:
1. **`IRepository` Interface**: Defines common data access methods.
2. **`GenericRepository` Implementation**: Provides a base class for data access.
3. **`IUnitOfWork` Interface**: Coordinates repository operations within a single transaction.
4. **`UnitOfWork` Implementation**: Manages repositories and commits changes to the database.

This project uses **Entity Framework Core** for ORM, providing a simple yet powerful mechanism for interacting with SQL Server databases.

## Prerequisites
- .NET 9 SDK
- SQL Server
- Visual Studio 2022 or a compatible IDE

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/aspire-playground.git
   ```

2. Navigate to the project directory:
   ```bash
   cd aspire-playground
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

1. 4. Apply migrations and update the database (just in case):
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. Run the application:
   ```bash
   dotnet run
   ```

## License
[![MIT License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)

This project is licensed under the MIT License, which allows you to freely use, modify, and distribute the code. See the [`LICENSE`](LICENSE) file for full details.