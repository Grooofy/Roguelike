using System.Numerics;
using ParentObjects;

namespace Bullet
{
    public class BulletModel : GameObjectModel
    {
        private readonly Vector2[] _directions =
        {
            new Vector2(0, -1),
            new Vector2(0, 1),
            new Vector2(1, 0),
            new Vector2(-1, 0)
        };

        public int Damage { get; private set; } = 1;


        public BulletModel(Vector2 startPosition) : base(startPosition)
        {
        }
        
        
        
    }
}
