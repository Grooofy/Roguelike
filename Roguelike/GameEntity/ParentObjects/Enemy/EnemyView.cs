using Map;
using ParentObjects;

namespace Enemy
{
    public class EnemyView : GameObjectView
    {
        public EnemyView(GameObjectModel enemyModel) : base(enemyModel, Symbol.Enemy)
        {
        }
    }
}
