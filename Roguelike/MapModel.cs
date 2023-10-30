namespace Roguelike
{
    public class MapModel
    {
        
        private Random random = new Random();
        private readonly char _wallSymbol = (char)Symbol.Wall;
        private readonly char _cleanCell = (char)Symbol.CleanCell;

        public char[,] Generate(int width, int height)
        {
            char[,] newMap = CreatePerimeterWalls(width, height);

            for (int i = 1; i < height - 1; i++)
            {
                newMap[1, i] = GetRandomChar();
            }

            for (int i = 2; i < width - 1; i++)
            {
                for (int j = 1; j < height -1; j++)
                {
                    if (newMap[i-1,j+1] == _wallSymbol && newMap[i-1,j] == _cleanCell )
                    {
                        newMap[i, j] = _cleanCell;
                    }
                    else
                    {
                        newMap[i, j] = GetRandomChar();
                    }
                }                
            }
            newMap[1, 1] = _cleanCell;
            newMap[width - 2, height - 3] = _cleanCell;
            return newMap;
        }

        private char GetRandomChar()
        {
            int randomValue = random.Next(2);

            if (randomValue == 0)
            {
                return _cleanCell;
            }

            return _wallSymbol;
        }

        private char[,] CreatePerimeterWalls(int width, int height)
        {
            char[,] newMap = new char[width, height];

            for (int i = 0; i < width; i++)
            {
                newMap[i, 0] = _wallSymbol;
                newMap[i, height - 1] = _wallSymbol;
            }

            for (int j = 1; j < height - 1; j++)
            {
                newMap[0, j] = _wallSymbol;
                newMap[width - 1, j] = _wallSymbol;
            }

            newMap[0, 1] = _cleanCell;
            newMap[width - 1, height - 2] = _cleanCell;
            return newMap;
        }
    }
}
