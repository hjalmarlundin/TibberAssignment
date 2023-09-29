namespace Cleaner.Application
{
    public interface IPathRequestHandler
    {
        Task<CleanResult> HandleRequest(CleanRequest request);
    }
}