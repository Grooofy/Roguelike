using System.Numerics;
using Interfaces;
using Map;
using ParentObjects;
using Player;

namespace Enemy
{
    public class EnemyController : GameObjectController
    {
        public EnemyController(IInputSystem inputSystem, MapController mapController, GameObjectModel gameObjectModel, GameObjectView gameObjectView) : base(inputSystem, mapController, gameObjectModel, gameObjectView)
        {
        }
    }
}
