namespace Cleaner.Repository
{

    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using Npgsql;

    public class Database(ILogger<Database> logger) : IDatabase
    {
        private readonly ILogger<Database> logger = logger;

        public async Task InitializeDb()
        {
            var con = new NpgsqlConnection(connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=password;Database=testdb;");

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
        }

        public async Task<int> InsertRecord(DateTime timestamp, int commands, int result, TimeSpan duration)
        {
            var con = new NpgsqlConnection(connectionString: "Server=localhost;Port=5432;User Id=postgres;Password=password;Database=testdb;");

            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;
            cmd.CommandText = $"INSERT INTO results (commands, result, duration, timestamp) VALUES (@command, @result, @duration, @timestamp) RETURNING id";
            cmd.Parameters.AddWithValue("command", commands);
            cmd.Parameters.AddWithValue("result", result);
            cmd.Parameters.AddWithValue("duration", NpgsqlTypes.NpgsqlDbType.Interval, duration);
            cmd.Parameters.AddWithValue("timestamp", NpgsqlTypes.NpgsqlDbType.Timestamp, timestamp);
            var id = await cmd.ExecuteScalarAsync() ?? throw new Exception("Could not retrieve ID from data");
            logger.LogInformation($"New ID {id}");
            return (int)id;
        }

    }
}
