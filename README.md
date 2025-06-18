# Merchant Management App

A .NET 8-based backend API for managing merchant data.

## 🚀 Getting Started

# Merchant Management App

## Getting Started

1. Install .NET 8

2. Use the following connection string in `Presentation/appsettings.json` under the `AZURE_SQL_DATABASE` JSON option:
"Server=tcp:learningdbazuresql.database.windows.net,1433;Initial Catalog=LearningDB;Persist Security Info=False;User ID=learningdb;Password=ewqeqw!#2fegerge;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
3. Command to create migration files: "dotnet ef migrations add InitialMigration --context MerchantDbContext --project Infrastructure --startup-project Presentation -o DataAccess/MerchantContext/Migrations"
4. Run the `DEV` configuration from `Presentation/Properties/launchSettings.json`
5. Open [http://localhost:5001/swagger/index.html](http://localhost:5001/swagger/index.html) to explore the API if needed.
