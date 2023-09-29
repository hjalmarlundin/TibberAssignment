using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Cleaner.Application;
using Swashbuckle.AspNetCore.Filters;

namespace Cleaner.Hosting
{
    public class PathExamples : IMultipleExamplesProvider<CleanRequest>
    {
        public IEnumerable<SwaggerExample<CleanRequest>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "Example 1",
                new CleanRequest()
                {
                    Start = new Coordinate() { x = 0, y = 0 },
                    Commands = [new() { direction = "East", steps = 3 }],
                }
            );

            yield return SwaggerExample.Create(
                "Example 2",
                new CleanRequest()
                {
                    Start = new Coordinate() { x = 10, y = 10 },
                    Commands = [new() { direction = "West", steps = 3 }, new() { direction = "North", steps = 6 }],
                }
            );
        }

        public CleanRequest GetExamples2()
        {
            return new CleanRequest()
            {
                Start = new Coordinate() { x = 10, y = 10 },
                Commands = [new() { direction = "West", steps = 3 }, new() { direction = "North", steps = 6 }],
            };
        }
    }

}