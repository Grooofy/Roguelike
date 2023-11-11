using Map;
using ParentObjects;

namespace Enemy
{
    public class WarriorView : GameObjectView
    {
        public WarriorView(GameObjectModel enemyModel) : base(enemyModel, Symbol.WarriorEnemy)
        {
        }
    }
}
