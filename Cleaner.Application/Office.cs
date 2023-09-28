namespace Cleaner.Application
{
    public class Office(int w = 200000, int h = 200000)
    {
        private readonly int Width = w;
        private readonly int Height = h;

        private readonly Dictionary<long, bool> _cells = [];

        public bool Get(Coordinate coordinate)
        {
            long index = coordinate.y * Width + coordinate.x;
            _cells.TryGetValue(index, out bool result);
            return result;
        }

        public void Set(Coordinate coordinate)
        {
            Set(coordinate.y, coordinate.x);
        }

        public void Set(IEnumerable<Coordinate> coordinate)
        {
            foreach (var coord in coordinate)
            {
                Set(coord);
            }
        }

        public int GetCount()
        {
            return _cells.Count;
        }

        private void Set(int row, int col)
        {
            long index = row * Width + col;
            _cells[index] = true;
        }
    }
}