using System.Numerics;
using Map;
using ParentObjects;

namespace Bullet
{
    public class BulletModel : GameObjectModel
    {
        public int Damage { get; private set; } = 1;
        
        public BulletModel(Vector2 startPosition) : base(startPosition)
        {
        }

        protected override void LookForward(Vector2 direction, MapController map)
        {
            base.LookForward(direction, map);
           
        }
    }
}
