using System.Numerics;
using Map;
using ParentObjects;
using Player;
using Roguelike.Interfaces;

namespace Enemy
{
    public class EnemyModel : GameObjectModel, IAttack
    {
        private int _damage = 1;
        private PlayerModel _playerModel;
        

        public EnemyModel(Vector2 startPosition, PlayerModel playerModel) : base(startPosition)
        {
            _playerModel = playerModel;
            RemoveToStartPosition();
        }

        public void Attack(GameObjectModel playerModel)
        {
            playerModel.TakeDamage(_damage);
        }

        protected override void LookForward(Vector2 direction, MapController map)
        {
            base.LookForward(direction, map);
            if (CurrentPosition == _playerModel.CurrentPosition)
            {
                Attack(_playerModel);
            }
        }

        
    }
}
