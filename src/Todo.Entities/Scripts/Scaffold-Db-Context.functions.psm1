$appSettingsPath = "..\..\Todo.Main\appsettings.json" 

function Get-ConnectionStringFromAppSettings {
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

Export-ModuleMember -Function Get-ConnectionString