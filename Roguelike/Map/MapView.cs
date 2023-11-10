namespace Map
{
    public class MapView
    {
        public void Show(char[,] _map)
        {
            for (int i = 0; i < _map.GetLength(0); i++)
            {
                for (int j = 0; j < _map.GetLength(1); j++)
                {
                    Console.Write(_map[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
