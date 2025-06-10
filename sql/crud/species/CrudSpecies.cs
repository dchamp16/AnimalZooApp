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

        public static void DeleteSpecies(string connString, int speciesId)
        {
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("DeleteSpecies Connected to the PostgreSQL database successfully.");
                string DeleteSpecies = @"
                DELETE FROM species 
                WHERE id = @speciesId;";
                using var cmd = new NpgsqlCommand(DeleteSpecies, conn);
                cmd.Parameters.AddWithValue("speciesId", speciesId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Species deleted successfully.");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error deleting species: {ex.Message}");
            }
        }

        public static void UpdateSpecies(string connString, int speciesId, string newSpeciesName)
        {
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("UpdateSpecies Connected to the PostgreSQL database successfully.");

                string updateSpecies = @"
            UPDATE species
            SET name = @newSpeciesName
            WHERE id = @speciesId;";

                using var cmd = new NpgsqlCommand(updateSpecies, conn);
                cmd.Parameters.AddWithValue("speciesId", speciesId);
                cmd.Parameters.AddWithValue("newSpeciesName", newSpeciesName);

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected == 0)
                {
                    Console.WriteLine($"Species with id {speciesId} does not exist.");
                }
                else
                {
                    Console.WriteLine("Species updated successfully.");
                }
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error updating species: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}