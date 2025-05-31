using System;
using DotNetEnv;
using AnimalZooApp.sql;


class Program
{
    static void Main(string[] args)
    {
        DotNetEnv.Env.Load();

        var host = Environment.GetEnvironmentVariable("PGHOST");
        var port = Environment.GetEnvironmentVariable("PGPORT");
        var username = Environment.GetEnvironmentVariable("PGUSER");
        var password = Environment.GetEnvironmentVariable("PGPASSWORD");
        var dbName = Environment.GetEnvironmentVariable("PGDATABASE");


        // Connection string for "postgres" database, used to create your own DB
        var adminConnString = $"Host={host};Port={port};Username={username};Password={password};";
        // Connection string for your specific DB
        var zooConnString = $"Host={host};Port={port};Username={username};Password={password};Database={dbName};";

        Console.WriteLine("Connecting to the PostgreSQL server...");
        // CreateDB.EnsureDatabase(adminConnString, dbName);
        // CreateTables.CreateAnimalTable(zooConnString);
        // CreateTables.CreateSpeciesTable(zooConnString);
        // CreateTables.CreateHabitatTable(zooConnString);
        // CreateTables.CreateKeepersTable(zooConnString);
        // CreateTables.CreateFeedingTable(zooConnString);
        // Console.WriteLine("All tables created successfully.");

        TestTable.SelectAllTablesTest(zooConnString);
        Console.WriteLine("All tables selected successfully.");




    }
}