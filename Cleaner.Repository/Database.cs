using Npgsql;

namespace Cleaner.Repository
{
    public class Database(string connectionString) : IDatabase
    {
        private readonly string connectionString = connectionString;

        private bool IsInitialized = false;

        public async Task InitializeDb() // For development purposes..
        {
            var con = new NpgsqlConnection(connectionString: connectionString);

            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"DROP TABLE IF EXISTS results";
            await cmd.ExecuteNonQueryAsync();

            cmd.CommandText = "CREATE TABLE results (id SERIAL PRIMARY KEY," +
                                "commands INT," +
                                "result int," +
                                "duration interval," +
                                "timestamp timestamp)";
            await cmd.ExecuteNonQueryAsync();
            IsInitialized = true;
        }

        public async Task<int> InsertRecord(DateTime timestamp, int commands, int result, TimeSpan duration)
        {
            if (!IsInitialized)
            {
                await InitializeDb();
            }

            var con = new NpgsqlConnection(connectionString);

            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO results (commands, result, duration, timestamp) VALUES (@command, @result, @duration, @timestamp) RETURNING id";
            cmd.Parameters.AddWithValue("command", commands);
            cmd.Parameters.AddWithValue("result", result);
            cmd.Parameters.AddWithValue("duration", NpgsqlTypes.NpgsqlDbType.Interval, duration);
            cmd.Parameters.AddWithValue("timestamp", NpgsqlTypes.NpgsqlDbType.Timestamp, timestamp);
            var id = await cmd.ExecuteScalarAsync() ?? throw new Exception("Could not retrieve ID from database");

            return (int)id;
        }

    }
}
