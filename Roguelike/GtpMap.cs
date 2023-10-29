namespace Roguelike
{
    public class GtpMap
    {
        private int width;
        private int height;
        private char[,] maze;

        public GtpMap(int width, int height)
        {
            this.width = width;
            this.height = height;
            maze = new char[width, height];
        }

        public void GenerateMaze()
        {
            // Инициализация лабиринта
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    maze[i, j] = '#'; // Построение стен
                }
            }

            // Генерация лабиринта
            Random random = new Random();
            int startX = random.Next(1, width - 1);
            int startY = random.Next(1, height - 1);
            maze[startX, startY] = ' ';

            GeneratePath(startX, startY);
        }

        private void GeneratePath(int x, int y)
        {
            int[] dx = { 1, -1, 0, 0 }; // Сдвиги по x
            int[] dy = { 0, 0, 1, -1 }; // Сдвиги по y

            Random random = new Random();
            int[] directions = { 0, 1, 2, 3 }; // Направления: 0 - вправо, 1 - влево, 2 - вниз, 3 - вверх
            Shuffle(directions);

            foreach (int direction in directions)
            {
                int nx = x + dx[direction] * 2;
                int ny = y + dy[direction] * 2;

                if (nx >= 0 && ny >= 0 && nx < width && ny < height && maze[nx, ny] == '#')
                {
                    maze[x + dx[direction], y + dy[direction]] = ' ';
                    maze[nx, ny] = ' ';
                    GeneratePath(nx, ny);
                }
            }
        }

        private void Shuffle(int[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }

        public void PrintMaze()
        {
            for (int j = 0; j < height; j++)
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write(maze[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}


