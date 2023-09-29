using System.Diagnostics;

namespace Cleaner.Application
{
    public interface IPathRequestHandler
    {
        Task<CleanResult> HandleRequest(CleanRequest request);
    }

    public class PathRequestHandler : IPathRequestHandler
    {
        public Task<CleanResult> HandleRequest(CleanRequest request)
        {
            var timer = Stopwatch.StartNew();
            var result = new CleanResult();
            var office = new Office();
            var start = request.Start;
            office.Set(start);

            foreach (var command in request.Commands)
            {
                var coordinates = CreateCoordinatesFromCommand(command, start);
                office.Set(coordinates);
                start = coordinates.Last();
                result.commands++;
            }

            result.result = office.GetCount();
            result.duration = timer.Elapsed;
            result.timestamp = DateTime.UtcNow;
            return Task.FromResult(result);

        }

        private List<Coordinate> CreateCoordinatesFromCommand(Command command, Coordinate start)
        {
            var coordinates = new List<Coordinate>() { };
            switch (command.direction.ToLower())
            {
                case "north":
                    for (int i = 1; i <= command.steps; i++)
                    {
                        coordinates.Add(start with { y = start.y + i });
                    }
                    break;

                case "south":
                    for (int i = 1; i <= command.steps; i++)
                    {
                        coordinates.Add(start with { y = start.y - i });
                    }
                    break;

                case "west":
                    for (int i = 1; i <= command.steps; i++)
                    {
                        coordinates.Add(start with { x = start.x - i });
                    }
                    break;

                case "east":
                    for (int i = 1; i <= command.steps; i++)
                    {
                        coordinates.Add(start with { x = start.x + i });
                    }
                    break;

                default:
                    throw new Exception($"Command {command.direction} does not exit");
            }

            return coordinates;
        }
    }
}