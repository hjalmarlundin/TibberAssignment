using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cleaner.Application
{
    public class Office
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public long Size { get; private set; }

        private readonly Dictionary<long, bool> _cells = [];

        public Office(int w = 200000, int h = 200000)
        {
            this.Width = w;
            this.Height = h;
            this.Size = w * h;
        }

        public bool IsCellEmpty(int row, int col)
        {
            return _cells.ContainsKey(row * Width + col);
        }

        public void Set(Coordinate coordinate)
        {
            Set(coordinate.y, coordinate.x);
        }

        public bool Get(Coordinate coordinate)
        {
            long index = coordinate.y * Width + coordinate.x;
            _cells.TryGetValue(index, out bool result);
            return result;
        }

        public void Set(IEnumerable<Coordinate> coordinate)
        {
            foreach (var coord in coordinate)
            {
                Set(coord);
            }
        }

        private void Set(int row, int col)
        {
            long index = row * Width + col;
            _cells[index] = true;
        }

        public int GetCount()
        {
            return _cells.Count;
        }
    }
}