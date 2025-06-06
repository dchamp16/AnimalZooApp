using Npgsql;

namespace AnimalZooApp.sql
{
    public static class CrudSpecies
    {
        public static void AddSpecies(string connString, string speciesName)
        {
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("AddSpecies Connected to the PostgreSQL database successfully.");
                string insertSpecies = @"
                INSERT INTO species (name)
                VALUES (@speciesName);";
                using var cmd = new NpgsqlCommand(insertSpecies, conn);
                cmd.Parameters.AddWithValue("speciesName", speciesName);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Species added successfully.");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error adding species: {ex.Message}");
            }
        }
    }
}