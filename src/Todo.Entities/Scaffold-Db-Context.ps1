param(
    [Parameter()]
    [string]$connectionString = $null
)

function Get-ConnectionStringFromAppSettings {
    $appSettingsPath = "..\Todo.Main\appsettings.json" 

    $appSettingsJsonObject =  Get-Content -Path $appSettingsPath | ConvertFrom-Json
    $connectionString = $appSettingsJsonObject.DatabaseOptions.ConnectionString
    $connectionString
}

function Get-ConnectionString{

    param(
        [string]$connectionStringFromParam
    )

    if($connectionStringFromParam){
        $connectionStringFromParam
    }
    else{
        $appSettingsConnectionString = Get-ConnectionStringFromAppSettings
        $appSettingsConnectionString
    }
}

$actualConnectionString = Get-ConnectionString -connectionStringFromParam $connectionString
dotnet ef dbcontext scaffold $actualConnectionString Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --context-dir ./ --force --no-onconfiguring