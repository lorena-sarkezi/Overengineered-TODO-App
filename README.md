#Heavy WIP

A little playground/training with concepts such as:
* configurable database connection string source (Appsettings or Azure KeyVault) through abstractions and a provider which returns the connection string with the consumer not knowing (or needing to care) where it's coming from 
* RBS - ordinary and admin user (admins can see and manage all TODOs), implementing RBS from scratch using JWT on frontend and backend
* Database migration and versioning scripts - because this is a database-first project and no EF Core native migration/upgrade functionality is available
* Playing with Zustand for global state management in React - https://github.com/pmndrs/zustand


CLI Tools used/will be used:
* dotnet tool install --global dotnet-ef
* az (Azure CLI)