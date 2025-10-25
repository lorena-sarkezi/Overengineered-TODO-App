param(
    [Parameter()]
    [string]$connectionString
)

dotnet ef dbcontext scaffold $connectionString Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir ./ --force --no-onconfiguring