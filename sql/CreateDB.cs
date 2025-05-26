using Npgsql;
using DotNetEnv;

namespace AnimalZooApp.sql
{
    public static class CreateDB
    {
        public static void EnsureDatabase(string adminConnString, string dbName)
        {
            using var conn = new NpgsqlConnection(adminConnString);
            conn.Open();
            Console.WriteLine("Connected to the PostgreSQL server successfully.");

            using var cmd = new NpgsqlCommand($"CREATE DATABASE {dbName};", conn);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Database {dbName} created successfully.");
            }
            catch (NpgsqlException ex)
            {
                if (ex.SqlState == "42P04") // Database already exists
                {
                    Console.WriteLine($"Database {dbName} already exists.");
                }
                else
                {
                    Console.WriteLine($"Error creating database: {ex.Message}");
                    throw;
                }
            }
        }
    }


}
