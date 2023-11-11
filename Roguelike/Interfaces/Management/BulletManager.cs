using System.Numerics;

namespace Interfaces
{
    public class BulletManager : IInputSystem
    {
        private Random _random = new Random();
        
        private readonly Vector2[] _directions =
        {
            new Vector2(0, -1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(-1, 0)
        };

        public Vector2 GetDirection()
        {
            return _directions[_random.Next(0, _directions.Length)];
        }
    }
}
