using System.Numerics;
using Interfaces;
using Map;
using ParentObjects;

namespace Bullet
{
    public class BulletModel : GameObjectModel
    {
        public Action<Vector2> HitedWall;
        
        public BulletModel(Vector2 startPosition, int speed) : base(startPosition, speed)
        {
        }

        public override void Move(IInputSystem inputSystem, MapController symbol)
        {
            Vector2 newDirection = inputSystem.GetDirection();
            while (IsDie == false)
            {
                Thread.Sleep(_speed);
                PreviousPosition = CurrentPosition;
                LookForward(newDirection, symbol);
            }
        }

        protected override void LookForward(Vector2 direction, MapController map)
        {
            Vector2 startPosition = CurrentPosition;
            Direction = CurrentPosition + direction;

            if (map.GetSymbolMap(Direction) == (char)Symbol.CleanCell)
            {
                SetNewPosition(direction);
            }
            else
            {
                CurrentPosition = startPosition;
                HitedWall?.Invoke(CurrentPosition);
            }
        }
    }
}
