# Ebay

# добавление пакетов
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package ConsoleTables --version 2.4.2

# генерация классов из БД (Database First)
Scaffold-DbContext "Server=127.0.0.1;Port=5432;Database=ebay;User Id=postgres;Password=PGAdmin;" Npgsql.EntityFrameworkCore.PostgreSQL -o Models
