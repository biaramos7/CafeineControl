using Npgsql;

namespace CaffeineControlAPI.Data
{
    public static class ConfigureDb
    {
        public static void CheckIfExist(string connectionString)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                var checkDbCommand = new NpgsqlCommand("SELECT 1 FROM pg_database WHERE datname = 'coffee_db'", connection);
                var dbExists = checkDbCommand.ExecuteScalar() != null;

                if (!dbExists)
                {
                    var createDbCommand = new NpgsqlCommand("CREATE DATABASE coffee_db", connection);
                    createDbCommand.ExecuteNonQuery();
                }

                connection.ChangeDatabase("coffee_db");

                var checkTableCommand = new NpgsqlCommand("SELECT EXISTS (SELECT 1 FROM information_schema.tables WHERE table_name = 'coffee')", connection);
                var tableExists = (bool)checkTableCommand.ExecuteScalar();

                if (!tableExists)
                {
                    var createTableCommand = new NpgsqlCommand("CREATE TABLE coffee (code varchar(3) PRIMARY KEY, name varchar(200), caffeine_level numeric)", connection);
                    createTableCommand.ExecuteNonQuery();

                    var insertDataCommand = new NpgsqlCommand(
                        "INSERT INTO coffee (name, code, caffeine_level) " +
                        "VALUES ('Black Coffee', 'blk', 95), " +
                        "('Espresso', 'esp', 63), " +
                        "('Cappuccino', 'cap', 63), " +
                        "('Latte', 'lat', 63), " +
                        "('Flat White', 'wht', 63), " +
                        "('Cold Brew', 'cld', 120), " +
                        "('Decaf Coffee', 'dec', 4)", connection);

                    insertDataCommand.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
