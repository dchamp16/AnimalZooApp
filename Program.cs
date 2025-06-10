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

        // testing purposes for tables
        // TestTable.SelectAllTablesTest(zooConnString);
        // Console.WriteLine("All tables selected successfully.");

        string choices = "";
        Console.WriteLine("Add || Delete || Update");

        switch (Console.ReadLine()?.ToLower())
        {
            case "add":
                Console.WriteLine("Choose number:\n1. Animal\n2. Species\n3. Habitat\n4. Keeper\n5. Feeding");
                int choice = int.Parse(Console.ReadLine() ?? "0");

                switch (choice)
                {
                    case 1:
                        CrudAnimal.AddAnimal(zooConnString, "Lion", 1, 1);
                        Console.WriteLine("Animal added successfully.");
                        break;
                    case 2:
                        Console.WriteLine("Adding a species...");
                        Console.Write("Enter species name: ");
                        string speciesName = Console.ReadLine();
                        CrudSpecies.AddSpecies(zooConnString, speciesName);
                        Console.WriteLine("Species added successfully.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
                break;
            case "delete":
                Console.WriteLine("deleting species");
                Console.Write("Enter species ID to delete: ");
                int speciesId = int.Parse(Console.ReadLine() ?? "0");
                CrudSpecies.DeleteSpecies(zooConnString, speciesId);
                Console.WriteLine("Species deleted successfully.");
                break;
            case "update":
                // Implement update logic here
                Console.Write("Enter species ID to update: ");
                int updateSpeciesId = int.Parse(Console.ReadLine() ?? "0");
                Console.Write("Enter new species name: ");
                string newSpeciesName = Console.ReadLine();
                CrudSpecies.UpdateSpecies(zooConnString, updateSpeciesId, newSpeciesName);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }





    }
}