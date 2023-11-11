using Map;
using ParentObjects;
using Roguelike.Interfaces;

namespace Enemy
{
    public class ArcherView : GameObjectView, IAttack
    {
        
        public ArcherView(GameObjectModel gameObjectModel, Symbol symbol) : base(gameObjectModel, symbol)
        {
        }

        public void Attack(GameObjectModel playerModel)
        {
            
        }
    }
}
