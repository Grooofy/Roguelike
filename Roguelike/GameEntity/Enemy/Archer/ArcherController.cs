using Interfaces;
using Map;
using ParentObjects;

namespace Enemy
{
    public class ArcherController : GameObjectController
    {
        public ArcherController(IInputSystem inputSystem, MapController mapController, GameObjectModel gameObjectModel, GameObjectView gameObjectView) : base(inputSystem, mapController, gameObjectModel, gameObjectView)
        {
        }
    }
}
