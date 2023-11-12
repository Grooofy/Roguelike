using Map;
using ParentObjects;

namespace Bullet
{
    public class BulletView : GameObjectView
    {
        public BulletView(BulletModel bulletModel, Symbol symbol) : base(bulletModel, symbol)
        {
            bulletModel.HitedWall += CleanCell;
        }
    }
}
