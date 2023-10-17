#!/bin/bash

git reset --hard origin/master

git pull

dotnet restore Domain/Domain.csproj
dotnet restore Application/Application.csproj
dotnet restore Infrastructure/Infrastructure.csproj
dotnet restore Contracts/Contracts.csproj
dotnet restore Persistence/Persistence.csproj
dotnet restore Presentation/Presentation.csproj

dotnet publish -o /var/www/app1

systemctl restart app1.service