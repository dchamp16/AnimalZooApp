using Npgsql;


namespace AnimalZooApp.sql
{
    public static class TestTable
    {
        //select * tables
        public static void SelectAllTablesTest(string connString)
        {
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("SelectAllTablesTest Connected to the PostgreSQL database successfully.");

                string[] zooAnimalTables = { "animals", "species", "habitats", "keepers", "feedings" };

                foreach (var table in zooAnimalTables)
                {
                    string selectQuesty = $"SELECT * FROM {table};";
                    using var cmd = new NpgsqlCommand(selectQuesty, conn);
                    using var reader = cmd.ExecuteReader();
                    Console.WriteLine($"Data from {table} table:");
                    if (reader.HasRows == false)
                    {
                        Console.WriteLine($"No data found in {table} table.");
                        continue;
                    }

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            Console.Write($"{reader.GetName(i)}: {reader[i]} ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"End of {table} table data.\n");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error selecting data from tables: {ex.Message}");
                return;
            }
        }
    }
}