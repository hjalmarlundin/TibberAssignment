namespace Cleaner.Application
{
    public record CleanResult
    {
        public int Id { get; set; }

        public DateTime timestamp { get; set; }

        public int commands { get; set; }

        public int result { get; set; }

        public TimeSpan duration { get; set; }
    }

}