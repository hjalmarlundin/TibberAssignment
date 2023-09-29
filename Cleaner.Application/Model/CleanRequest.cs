namespace Cleaner.Application
{
    public class CleanRequest
    {
        public required Coordinate Start { get; set; }

        public required List<Command> Commands { get; set; }
    }

}