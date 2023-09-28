namespace Cleaner.Application
{
    public record CleanResult
    {
        public int Id;

        public DateTime timestamp;

        public int commands;

        public int result;

        public TimeOnly duration;
    }

}