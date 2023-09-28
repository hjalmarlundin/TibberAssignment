namespace Cleaner.Application
{
    public class CleanRequest
    {
        public required Coordinate Start;

        public required List<Command> Commands;
    }

}