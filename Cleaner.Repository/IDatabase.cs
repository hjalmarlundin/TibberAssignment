namespace Cleaner.Repository
{

    using System.Threading.Tasks;

    public interface IDatabase
    {
        Task InitializeDb();

        Task<int> InsertRecord(DateTime timestamp, int commands, int result, TimeSpan duration);
    }
}
