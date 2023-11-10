using System.Numerics;
using Map;
using Roguelike.Interfaces;

namespace Player
{
    public class PlayerModel
    {
        private int _health;
        private Vector2 _currentPosition;
        private readonly Vector2 _startPosition;

        public Vector2 PreviousPosition { get; private set; }
        public Action<Vector2> Moved;
        public bool IsDie;

        public PlayerModel(int health, Vector2 startPosition)
        {
            _health = health;
            _startPosition = startPosition;
            RemovePlayerToStartPosition();
        }

        public void RemovePlayerToStartPosition()
        {
            _currentPosition = _startPosition;
            Moved?.Invoke(_currentPosition);
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

        public void Move(IInputSystem inputSystem, char[,] map)
        {
            PreviousPosition = _currentPosition;
            LookForward(inputSystem.GetDirection(), map);
            Moved?.Invoke(_currentPosition);
        }

        private void LookForward(Vector2 direction, char[,] map)
        {
            var forward = _currentPosition + direction;

            if (map[(int)forward.Y, (int)forward.X] == (char)Symbol.CleanCell)
                SetNewPosition(direction);
            else
                _currentPosition = PreviousPosition;
        }
        
        private void SetNewPosition(Vector2 direction)
        {
            _currentPosition += direction;
        }
    }
}
