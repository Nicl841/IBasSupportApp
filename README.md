# IBas Support App

**Forfatter:** Niclas

## Formål
Blazor Web App til håndtering af kundehenvendelser for en cykelvirksomhed. Gemmer data i Azure CosmosDB.

## Opret CosmosDB Database
```bash
# Sæt variable
export RESGRP="din-resource-group"
export DBACCOUNT="din-cosmosdb-account"
export DATABASE="IBasSupportDB"
export CONTAINER="ibassupport"

# Opret database og container
az cosmosdb create --name $DBACCOUNT --resource-group $RESGRP
az cosmosdb sql database create --account-name $DBACCOUNT --resource-group $RESGRP --name $DATABASE
az cosmosdb sql container create --account-name $DBACCOUNT --resource-group $RESGRP \
  --database-name $DATABASE --name $CONTAINER --partition-key-path "/category"
```

## Installation for andre udviklere

1. Clone projektet:
```bash
git clone https://github.com/Nicl841/IBasSupportApp.git
cd IBasSupportApp
```

2. Opret din egen konfigurationsfil:
```bash
cp appsettings.example.json appsettings.json
```

3. Opdater `appsettings.json` med din CosmosDB connection string fra Azure Portal

4. Installer dependencies og kør:
```bash
dotnet restore
dotnet run
```

## Kør applikationen
```bash
dotnet run
```

## Status
**Nået:** Model, CosmosDB integration, opret/vis henvendelser  
**Mangler:** Edit, delete, filtrering, søgning  
**Næste skridt:** Implementere filtreringsmuligheder og edit/delete funktionalitet