# Files Upload Assessment

## 📦 Installation and execution

```bash
# Cloning the repository and accessing the directory
git clone git@github.com:MatheusBonadio/files-upload-assessment.git && cd files-upload-assessment

# Installing the dependencies
dotnet reverse

# Building project
dotnet build

# Generating database migration
dotnet ef migrations add v1 --project Infra

# Running migration on database
dotnet ef database update --project Infra

# Running project
dotnet run --project WebUI
```

## 🛠️ Technologies

- [C#](https://learn.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/)
- [.NET Core 3.1](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-core-3-1)
- [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0)
- [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-2019/)

## 📄 License

MIT © Matheus Bonadio
