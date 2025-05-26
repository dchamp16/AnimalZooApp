using Npgsql;


namespace AnimalZooApp.sql
{
    public static class CreateTables
    {
        public static void CreateSpeciesTable(string connString)
        {
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("CreateSpeciesTable Connected to the PostgreSQL database successfully.");

                string createSpecies = @"
                CREATE TABLE IF NOT EXISTS species(
                id SERIAL PRIMARY KEY,
                name VARCHAR(50) NOT NULL);";
                using var cmd = new NpgsqlCommand(createSpecies, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Species table created successfully.")
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error creating species table: {ex.Message}");
                return;
            }
        }

        public static void CreateHabitatTable(string connString)
        {
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("CreateHabitatTable Connected to the PostgreSQL database successfully.");
                string createHabitatTable = @"
                CREATE TABLE IF NOT EXISTS habitats(
                id SERIAL PRIMARY KEY,
                name VARCHAR(50) NOT NULL);";
                using var cmd = new NpgsqlCommand(createHabitatTable, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Habitat table created successfully.");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error creating habitat table: {ex.Message}");
                return;
            }
        }


        public static void CreateAnimalTable(string connString)
        {
            try
            {
                using var conn = new NpgsqlConnection(connString);
                conn.Open();
                Console.WriteLine("CreateAnimalTable Connected to the PostgreSQL database successfully.");

                string createAnimals = @"
                CREATE TABLE IF NOT EXISTS animals(
                id SERIAL PRIMARY KEY,
                name VARCHAR(50) NOT NULL,
                species_id INT NOT NULL REFERENCES species(id),
                habitat_id INT NOT NULL REFERENCES habitats(id));";

                using var cmd = new NpgsqlCommand(createAnimals, conn);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Animals table created successfully.");
            }
            catch (NpgsqlException ex)
            {
                Console.WriteLine($"Error creating animals table: {ex.Message}");
                return;
            }

        }



    }
}