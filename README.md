# PortalBooks

**About the project:**

* An web Application built using ASP.NET 6.0.
* Domain-Driven Design (DDD) architecture for a clean code base project.
* It uses the Entity Framework Core for creating migrations and database implementations.

**Technologies:**

* C#
* Entity Framework Core
* ASP.NET Core 6.0

## First steps

**Requirements:**

* .NET Core 6.0 ([https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download))
* Visual Studio Code, Rider or other IDE by your own prefference
* PostgreSQL Database

**Configuration:**

1. Clone this repo.
2. Update the connectionString in `appsettings.json` to setup your PostgreSQL database.
3. Open the solution in the IDE you want that supports CSharp Development.

## Running the Application

1. **Migrations:**
    * Be sure that you have previously created an PostgreSQL instance.
    * If you haven't ran the migrations yet, run the following command on Terminal in the project root folder:
       ```bash
       dotnet ef database update -p Infra -s Api
       ```
2. **Executing:**
    * **On Visual Studio:** Press F5 or click in Run button.
    * **Command Line Interface:**
       ```bash
       dotnet run -p Api
       ```

## Project Structure

* **Api**
    * Controllers to keep API endpoints.
    * Models for data transfer.
    * Logical services and other implementations
    
* **Application**
    * Business rules.
    * Repository inteface and other dependencies.
    
* **Domain**
    * Logic domain and other entities
    
* **Infra**
    * Repositories
    * EF Core Configuration.
