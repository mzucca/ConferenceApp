# ReHub Data model
I this document we'll explore the details of the data access layer for the Rehub project.
This project uses entity framework core to access database data. We adopted the multiple project approach to support different database.
At the moment only <b>PostgreSQL</b> is supported.
## Inheritance
To map inheritance we adopted the TPT (Table per Type) approach. 


## PostgreSQL
to create the database from powershell:
1. Set the connection string in the environment variables like <i>ReHub__DbConfiguration__ConnectionString=Host=localhost; Database=ReHub; Username=rehub; Password=rehub</i>
2. to <b>create migrations</b> <i>dotnet ef migrations add InitialCreate --context ReHub.Persistence.DataContext --project ..\Persistence\ReHub.Persistence.csproj </i> (From the backendAPI folder)
3. to <b>create the database</b> <i>dotnet ef database update</i>

# TODO
1. <b>Remove TEMP folder</b>