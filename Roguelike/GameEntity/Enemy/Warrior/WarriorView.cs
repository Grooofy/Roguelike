using Map;
using ParentObjects;

namespace Enemy
{
    public class WarriorView : GameObjectView
    {
        private static Symbol SYMBOL = Symbol.WarriorEnemy;
        public WarriorView(GameObjectModel enemyModel) : base(enemyModel, SYMBOL)
        {
        }
    }
}
