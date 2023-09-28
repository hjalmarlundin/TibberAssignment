using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Cleaner.Application
{
    public class PathRequestHandler
    {
        public PathRequestHandler()
        {

        }

        public CleanResult HandleRequest(CleanRequest request)
        {

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
            return result;

        }

        private List<Coordinate> CreateCoordinatesFromCommand(Command command, Coordinate start)
        {
            var coordinates = new List<Coordinate>() { };
            switch (command.direction)
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
                    throw new Exception($"Command {command} does not exit");
            }

            return coordinates;
        }
    }
}