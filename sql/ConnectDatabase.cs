using Npgsql;

namespace AnimalZooApp.sql
{
    public static class ConnectDatabase
    {
        public static void ConnectDB(string connString)
        {
            // TODO working progress need to be reusable for other classes
            // This method is used to connect to the PostgreSQL database using the provided connection string.
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("Connected to the PostgreSQL database successfully.");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }
        }
    }
}