using Map;
using ParentObjects;
using Roguelike.Interfaces;

namespace Enemy
{
    public class ArcherView : GameObjectView
    {
        private static Symbol SYMBOL = Symbol.ArcherEnemy;
        public ArcherView(GameObjectModel gameObjectModel) : base(gameObjectModel, SYMBOL)
        {
        }
    }
}
