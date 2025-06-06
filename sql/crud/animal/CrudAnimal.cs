using Npgsql;

namespace AnimalZooApp.sql
{
    public static class CrudAnimal
    {
        public static void AddAnimal(string connString, string name, int speciesId, int habitatId)
        {
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("AddAnimal Connected to the PostgreSQL datbase successfully.");
                string insertAnimal = @"
                INSERT INTO animals (name, species_id, habitat_id)
                VALUES (@name, @speciesId, @habitatId);";
                using var cmd = new NpgsqlCommand(insertAnimal, conn);
                cmd.Parameters.AddWithValue("name", name);
                cmd.Parameters.AddWithValue("speciesId", speciesId);
                cmd.Parameters.AddWithValue("habitatId", habitatId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Animal added successfully.");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error adding animal: {ex.Message}");
            }

        }
    }
}