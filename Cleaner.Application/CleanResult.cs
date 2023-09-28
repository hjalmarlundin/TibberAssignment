using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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