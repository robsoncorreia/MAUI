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
