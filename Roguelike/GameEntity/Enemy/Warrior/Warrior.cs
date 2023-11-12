using System.Numerics;
using Interfaces;
using Map;
using Player;

namespace Enemy
{
    public class Warrior
    {
        private Random _random = new Random();
        private AiInput _aiInput = new AiInput();
        private int _speed = 1000;
        private int _positionX;
        private int _positionY;

        public void CreateWarriors(MapController mapController, PlayerModel player, int count)
        {
            for (int i = 0; i < count; i++)
            {
                _positionX = _random.Next(1, mapController.Weight);
                _positionY = _random.Next(1, mapController.Height);
                CreateWarrior(mapController, player);
            }
        }
        
        private void CreateWarrior(MapController mapController, PlayerModel player)
        {
            WarriorModel warriorModel = new WarriorModel(new Vector2(_positionX,_positionY),player, _speed);
            WarriorView warriorView = new WarriorView(warriorModel);
            WarriorController archerController = new WarriorController(_aiInput, mapController, warriorModel, warriorView);
            archerController.Manage();
        }
    }
}
