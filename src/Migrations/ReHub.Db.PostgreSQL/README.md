# PostgreSQL
to create the database from powershell:
1. Set the connection string in the environment variables like <i>ReHub__DbConfiguration__ConnectionString=Host=localhost; Database=ReHub; Username=rehub; Password=rehub</i>
2. to <b>create migrations</b> <i>dotnet ef migrations add InitialCreate --context ReHub.Db.PostgreSQL.PostgresDbContext --project D:\Source\repos\ConferenceApp\src\Migrations\ReHub.Db.PostgreSQL\ReHub.Db.PostgreSQL.csproj</i>
3. to <b>create the database</b> <i>dotnet ef database update</i>