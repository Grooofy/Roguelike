using System.Numerics;
using Interfaces;
using Map;

namespace ParentObjects
{
    public class GameObjectModel
    {
        private readonly Vector2 _startPosition;
        protected int Health;
        protected Vector2 Direction;
        public bool IsDie;
        public Vector2 CurrentPosition { get; protected set; }
        public Vector2 PreviousPosition { get; private set; }
        public Action<Vector2, bool> Moved;
        public Action<int> TakingDamage;

        public GameObjectModel(Vector2 startPosition)
        {
            _startPosition = startPosition;
        }

        public void RemoveToStartPosition()
        {
            CurrentPosition = _startPosition;
            Moved?.Invoke(CurrentPosition, false);
        }

        public void Move(IInputSystem inputSystem, MapController symbol)
        {
            PreviousPosition = CurrentPosition;
            LookForward(inputSystem.GetDirection(), symbol);
        }
        
        public void TakeDamage(int damage)
        {
            if (Health <= 0)
            {
                Health = 0;
                IsDie = true;
                return;
            }

            Health -= damage;
            TakingDamage?.Invoke(Health);
        }

        protected virtual void LookForward(Vector2 direction, MapController map)
        {
            Direction = CurrentPosition + direction;

            if (map.GetSymbolMap(Direction) == (char)Symbol.CleanCell)
            {
                SetNewPosition(direction);
            }
            else
            {
                CurrentPosition = PreviousPosition;
                Moved?.Invoke(CurrentPosition, false);
            }
        }

        protected void SetNewPosition(Vector2 direction)
        {
            CurrentPosition += direction;
            Moved?.Invoke(CurrentPosition, true);
        }
    }
}
