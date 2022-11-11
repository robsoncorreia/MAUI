# MAUI
<!--
## Android

![Android](img/Captura%20de%20tela%202022-11-06%20025258.png)

## Windows

![Windows](img/Captura%20de%20tela%202022-11-06%20031055.png)-->

## Microsoft SQL Server - Ubuntu based images

### Pull

```powershell
docker pull mcr.microsoft.com/mssql/server
```

### Start a mssql-server instance for SQL Server 2022, which is currently in public preview

```powershell
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

### Lists available migrations

```powershell
dotnet ef migrations list
```

### The following examples update the database to a specified migration. The first uses the migration name and the second uses the migration ID and a specified connection

```powershell
dotnet ef database update target_migration --connection your_connection_string
```

# Safe storage of app secrets in development in ASP.NET Core

### The Secret Manager tool includes an init command. To use user secrets, run the following command in the project directory

```powershell
dotnet user-secrets init
```

### Define an app secret consisting of a key and its value. The secret is associated with the project's UserSecretsId value. For example, run the following command from the directory in which the project file exists

```powershell
dotnet user-secrets set "Movies:ServiceApiKey" "12345"
```

### List: Run the following command from the directory in which the project file exists

```powershell
dotnet user-secrets list
```

### Remove: Run the following command from the directory in which the project file exists

```powershell
dotnet user-secrets remove "Movies:ConnectionString"
```

### Remove All: Run the following command from the directory in which the project file exists

```powershell
dotnet user-secrets clear
```

# Managing Secrets in .NET Console Apps

### Install the UserSecrets Package

```powershell
dotnet add package Microsoft.Extensions.Configuration.UserSecrets
```

### Access Secrets in Code

```csharp
using Microsoft.Extensions.Configuration;
```

```csharp
var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
string username = config["username"];
string password = config["password"];
```
