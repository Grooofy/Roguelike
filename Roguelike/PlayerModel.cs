using System.Numerics;

namespace Roguelike
{
    public class PlayerModel
    {
        private int _health;
        private Vector2 _currentPosition;
        private readonly Vector2 _directionUp = new Vector2(0, -1);
        private readonly Vector2 _directionDown = new Vector2(0, 1);
        private readonly Vector2 _directionRight = new Vector2(1, 0);
        private readonly Vector2 _directionLeft = new Vector2(-1, 0);
        
        public Vector2 PreviousPosition { get; private set; }
        public Action<Vector2> Moved;
        public bool IsDie;

        public PlayerModel(int health, Vector2 startPosition)
        {
            _health = health;
            _currentPosition = startPosition;
        }

        public void TryTakeDamage(int damage)
        {
            if (damage < 0) return;
            
            _health -= damage;
            
            if (_health <= 0)
            {
                _health = 0;
                IsDie = true;
            }
        }

        public void TryMove(ConsoleKeyInfo keyKode, int width, int height)
        {
            if (_currentPosition.X - _directionLeft.X < 0) return;
            if (_currentPosition.Y - _directionLeft.Y < 0) return;
            if (_currentPosition.X - _directionLeft.X > width) return;
            if (_currentPosition.Y - _directionLeft.Y > height) return;
            
            Move(keyKode);
            PreviousPosition = _currentPosition;
        }

        private void Move(ConsoleKeyInfo keyKode)
        {
            switch (keyKode.Key)
            {
                case ConsoleKey.UpArrow:
                    SetNewPosition(_directionUp);
                    break;
                case ConsoleKey.DownArrow:
                    SetNewPosition(_directionDown);
                    break;
                case ConsoleKey.RightArrow:
                    SetNewPosition(_directionRight);
                    break;
                case ConsoleKey.LeftArrow:
                    SetNewPosition(_directionLeft);
                    break;
            }
        }

        private void SetNewPosition(Vector2 direction)
        {
            _currentPosition += direction;
            Moved?.Invoke(_currentPosition);
        }
    }
}