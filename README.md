# Forecast and Budget Management Application

This project is a WPF application for managing forecast and budget plans. It connects to a Microsoft SQL Server database and uses Entity Framework for data access.

## Setting Up the Development Environment

1. Install the latest LTS version of .NET SDK from the [official website](https://dotnet.microsoft.com/download).
2. Install Visual Studio with the following workloads:
   - .NET desktop development
   - Data storage and processing
3. Clone the repository:
   ```
   git clone https://github.com/githubnext/workspace-blank.git
   ```
4. Open the solution file in Visual Studio.
5. Restore the NuGet packages:
   ```
   dotnet restore
   ```
6. Update the connection string in `appsettings.json` to point to your SQL Server instance.

## Running the Application

1. Build the solution in Visual Studio.
2. Apply the initial database migration:
   ```
   dotnet ef database update
   ```
3. Run the application from Visual Studio.
