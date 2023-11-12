using Bullet;
using Interfaces;
using Map;
using ParentObjects;
using Player;
using Roguelike.Interfaces;

namespace Enemy
{
    public class ArcherController : GameObjectController, IAttack
    {
        private BulletController _bulletController;
        private BulletModel _bulletModel;
        private int _bulletSpeed = 800;

        public ArcherController(
            IInputSystem inputSystem, MapController mapController, GameObjectModel gameObjectModel,
            GameObjectView gameObjectView, PlayerModel playerModel) :
            base(inputSystem, mapController, gameObjectModel, gameObjectView)
        {
            Attack(playerModel);
        }

        public async void Attack(GameObjectModel playerModel)
        {
            await Task.Run(() => Shoot(playerModel));
        }

        private void Shoot(GameObjectModel playerModel)
        {
            CreateBullet();
            _bulletController.Create();
            while (true)
            {
                Thread.Sleep(5000);
                _bulletController.Manage();
                if (_bulletModel.CurrentPosition == playerModel.CurrentPosition)
                {
                    _bulletController.Attack(playerModel);
                }
            }
        }

        private void CreateBullet()
        {
            _bulletModel = new BulletModel(_gameObjectModel.CurrentPosition, _bulletSpeed);

            _bulletController = new BulletController(new BulletManager(), _mapController, _bulletModel,
                new BulletView(_bulletModel, Symbol.Bullet));
        }
    }
}
