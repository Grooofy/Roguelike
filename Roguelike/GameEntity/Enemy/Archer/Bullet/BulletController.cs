using Interfaces;
using Map;
using ParentObjects;
using Roguelike.Interfaces;

namespace Bullet
{
    public class BulletController : GameObjectController , IAttack
    {
        public int Damage { get; private set; } = 1;

        public BulletController(IInputSystem inputSystem, MapController mapController, GameObjectModel gameObjectModel,
            GameObjectView gameObjectView) : base(inputSystem, mapController, gameObjectModel, gameObjectView)
        {
        }

        public void Attack(GameObjectModel playerModel)
        {
            playerModel.TakeDamage(Damage);
        }

        public override void Manage()
        {
            _gameObjectModel.Move(_inputSystem, _mapController);
        }
    }
}
