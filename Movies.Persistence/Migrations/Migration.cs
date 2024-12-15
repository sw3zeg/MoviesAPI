using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Npgsql;

namespace Movies.Persistence.Migrations;

public class Migration
{
    private readonly IConfiguration _configuration;

    public Migration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    // Instruction to do abd apply new migration
    // 1. Create .sql file with code
    // 2. Right mouse button and chose Properties
    // 3. Chose buildAction: EmbeddedResources
    // 4. From some entry point start this method
    //
    // To run in program.cs
    // Migration m = new Migration(builder.Configuration);
    // m.DoMigrations();
    // throw new Exception("all okey");
    public void DoMigrations()
    {
        // Строка подключения к PostgreSQL
        var connectionString = _configuration.GetConnectionString("PostgresConnection");

        Console.WriteLine("=========================");
        Console.WriteLine(connectionString);
        Console.WriteLine("=========================");
        
        // Настройка и создание миграций
        var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString) // Поддержка PostgreSQL
            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly()) // Скрипты миграций
            .LogToConsole() // Логирование в консоль
            .Build();

        // Применение миграций
        var result = upgrader.PerformUpgrade();

        // Проверка успешности
        if (!result.Successful)
        {
            Console.WriteLine(result.Error);
            return;
        }

        Console.WriteLine("Success! Migrations applied.");
    }
    
}