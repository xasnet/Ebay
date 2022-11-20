# Ebay
PackageReference:
PS> dotnet add package Microsoft.EntityFrameworkCore
PS> dotnet add package Microsoft.EntityFrameworkCore.Design
PS> dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
PS> dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
PS> dotnet add package ConsoleTables --version 2.4.2
Database First
PS> Scaffold-DbContext "Server=127.0.0.1;Port=5432;Database=ebay;User Id=postgres;Password=PGAdmin;" Npgsql.EntityFrameworkCore.PostgreSQL -o Models