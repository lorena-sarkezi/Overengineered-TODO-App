param(
    [Parameter()]
    [string]$connectionString = $null
)

Import-Module ./Scaffold-Db-Context.functions.psm1

$actualConnectionString = Get-ConnectionString -connectionStringFromParam $connectionString
dotnet ef dbcontext scaffold $actualConnectionString Microsoft.EntityFrameworkCore.SqlServer --project '..\Todo.Entities.csproj' --output-dir Models --context-dir ./ --force --no-onconfiguring