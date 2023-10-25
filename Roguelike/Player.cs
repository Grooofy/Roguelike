using System.Numerics;

namespace Roguelike
{
    public class Player
    {
        private int _health;
        private char _symbol = '@';
        private Vector2 _currentPosition = new Vector2(0,0);

        private void Move(ConsoleKeyInfo keyKode)
        {
            keyKode = Console.ReadKey();

            switch (keyKode.Key)
            {
                case ConsoleKey.UpArrow:
                    SetNewPosition(0,1);
                    break;
                case ConsoleKey.DownArrow:
                    SetNewPosition(0,-1);
                    break;
                case ConsoleKey.RightArrow:
                    SetNewPosition(1,0);
                    break;
                case ConsoleKey.LeftArrow:
                    SetNewPosition(-1,0);
                    break;
            }
        }

        private void SetNewPosition(int x, int y)
        {
            _currentPosition += new Vector2(x,y);
        }

    }
}
