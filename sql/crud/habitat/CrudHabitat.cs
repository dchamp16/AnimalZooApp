// TODO Habitats CRUD operations

using Npgsql;

namespace AnimalZooApp.sql
{
    public static class CrudHabitat
    {
        public static void AddHabitat(string connString, string habitatName)
        {
            try
            {

                string insertHabitat = @"
                INSERT INTO habitats (name)
                VALUES (@habitatName);";

                using var cmd = new NpgsqlCommand(insertHabitat, ConnectDatabase.ConnectDB(connString));
            }
        }
    }
}