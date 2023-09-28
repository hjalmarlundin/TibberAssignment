using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleaner.Application.Tests
{
    public class CleanRequestBuilder
    {
        private CleanRequest request = new CleanRequest() { Start = new Coordinate() { x = 0, y = 0 }, Commands = new List<Command>() };

        public CleanRequest Build()
        {
            return request;
        }

        public CleanRequestBuilder WithStart(int x, int y)
        {
            request.Start = new Coordinate() { x = x, y = y };
            return this;
        }

        public CleanRequestBuilder WithCommand(string direction, int steps)
        {
            request.Commands.Add(new Command() { direction = direction, steps = steps });
            return this;
        }
    }
}