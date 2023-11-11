using Interfaces;
using Map;
using ParentObjects;

namespace Bullet
{
    public class BulletController : GameObjectController
    {
        public BulletController(IInputSystem inputSystem, MapController mapController, GameObjectModel gameObjectModel, GameObjectView gameObjectView) : base(inputSystem, mapController, gameObjectModel, gameObjectView)
        {
        }
    }
}
