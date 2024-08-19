# StudentAPI

## Installation
### Database
Create a new `studentdb` database:
```sql
create database studentdb;
```

Update `appsettings.json` and set your connection string:
```json
"ConnectionStrings": {
    "DBConn": "Server=localhost;port=3306;Database=studentdb;User Id=root;Password=1234;"
}
```

Run The Migrations: `Tools` -> `NuGet Package Manager` -> `Package Manager Console`:
```
Update-Database
```