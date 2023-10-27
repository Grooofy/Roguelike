namespace Roguelike
{
    public class Map
    {
        private int[,] _size;
        private char _wallSymbol = '#';
        
        public Map(int height, int width)
        {
            _size = new int[height, width];
        }

        public void ShowMap()
        {
            for (int i = 0; i < _size.GetLength(0); i++)
            {
                for (int j = 0; j < _size.GetLength(1); j++)
                {
                    Console.Write(_wallSymbol);
                }
                Console.WriteLine();
            }
        }
    }
}
