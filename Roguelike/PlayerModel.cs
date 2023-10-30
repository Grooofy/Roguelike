using System.Numerics;

namespace Roguelike
{
    public class PlayerModel
    {
        private int _health;
        public Action<Vector2> Moved;
        public Vector2 CurrentPosition { get; private set; }
        public Vector2 PreviousPosition { get; private set; }

        public PlayerModel(int health)
        {
            _health = health;
            CurrentPosition = new Vector2(1, 0);
        }

        public void Move(ConsoleKeyInfo keyKode)
        {
            switch (keyKode.Key)
            {
                case ConsoleKey.UpArrow:
                    SetNewPosition(0, -1);
                    Moved?.Invoke(CurrentPosition);
                    break;
                case ConsoleKey.DownArrow:
                    SetNewPosition(0, 1);
                    Moved?.Invoke(CurrentPosition);
                    break;
                case ConsoleKey.RightArrow:
                    SetNewPosition(1, 0);
                    Moved?.Invoke(CurrentPosition);
                    break;
                case ConsoleKey.LeftArrow:
                    SetNewPosition(-1, 0);
                    Moved?.Invoke(CurrentPosition);
                    break;
            }
        }

        private void SetNewPosition(int x, int y)
        {
            PreviousPosition = CurrentPosition;
            CurrentPosition += new Vector2(x, y);
        }
    }
}