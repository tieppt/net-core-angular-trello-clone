# Trollo API

## Install Entity Framework CLI

```bash
dotnet tool install --global dotnet-ef
```

## Run Migration

```bash
dotnet ef database update --context=AppDbContext
```

```bash
dotnet ef database update --context=AppIdentityDbContext
```