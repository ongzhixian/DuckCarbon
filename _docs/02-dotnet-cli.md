# dotnet CLI

dotnet new globaljson
dotnet new sln -n DuckCarbon
dotnet new web -n DuckCarbon.CountryApi
dotnet sln .\DuckCarbon.sln add .\DuckCarbon.CountryApi\


dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
dotnet nuget list source


dotnet add .\DuckCarbon.CountryApi\ package Serilog
dotnet add .\DuckCarbon.CountryApi\ package Serilog.Extensions.Hosting
dotnet add .\DuckCarbon.CountryApi\ package Serilog.Settings.Configuration
dotnet add .\DuckCarbon.CountryApi\ package Serilog.Formatting.Compact
dotnet add .\DuckCarbon.CountryApi\ package Serilog.Sinks.Console
dotnet add .\DuckCarbon.CountryApi\ package Serilog.Sinks.File
dotnet add .\DuckCarbon.CountryApi\ package Swashbuckle.AspNetCore
dotnet add .\DuckCarbon.CountryApi\ package MongoDB.Driver

dotnet user-secrets init --project .\DuckCarbon.CountryApi\
dotnet user-secrets set <some-key> <some-value> --project .\DuckCarbon.CountryApi\
dotnet user-secrets list --project .\DuckCarbon.CountryApi\

dotnet run --project .\DuckCarbon.CountryApi\ --environment Production

## Remarks

For some reason, `dotnet nuget` and the package manage in `Visual Studio`  
did not have `nuget.org` have package source.
So we have to manually add it (see line 9)
