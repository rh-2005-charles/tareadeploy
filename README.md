# Proyecto IC Tienda

Este es un sistema de gestión para una tienda en línea.

## Requisitos

- .NET 8.0
- SQLite

## Instalación

1. Clona el repositorio:

   ```bash
   git clone https://github.com/rh-2005-charles/Crud-Example.git

2. Restaura los paquetes NuGet:

    ```bash
    dotnet restore

3. Copila todo el proyecto:

    ```bash
    dotnet build

## Comandos Utiles

1. Instalación de dotnet ef:

    ```bash
    dotnet tool install --global dotnet-ef

2. Para realizar una migración:

    ```bash
    dotnet ef migrations add NombreMigracion

3. Para actualizar la base de datos:

    ```bash
    dotnet ef database update

4. Para ejecutar:

    ```bash
    dotnet watch run --launch-profile https