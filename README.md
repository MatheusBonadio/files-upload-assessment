## 📦 Installation and execution

```bash
# Cloning the repository and accessing the directory
git clone git@github.com:MatheusBonadio/files-upload-assessment.git && cd files-upload-assessment

# Installing the dependencies
dotnet build

# Generating database migration
dotnet ef migrations add v1 --project Infra

# Running migration on database
dotnet ef database update --project Infra

# Running unity tests
dotnet test

# Running project
dotnet run --project WebUI
```
