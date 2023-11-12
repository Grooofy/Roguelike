using System.Numerics;
using Interfaces;
using Map;
using Player;

namespace Enemy
{
    public class Archer
    {
        private Random _random = new Random();
        private AiInput _aiInput = new AiInput();
        private int _speed = 1000;
        private int _positionX;
        private int _positionY;

        public void CreateArchers(MapController mapController, PlayerModel player, int count)
        {
            for (int i = 0; i < count; i++)
            {
                _positionX = _random.Next(1, mapController.Weight);
                _positionY = _random.Next(1, mapController.Height);
                CreateArcher(mapController, player);
            }
        }
        
        private void CreateArcher(MapController mapController, PlayerModel player)
        {
            ArcherModel archerModel = new ArcherModel(new Vector2(_positionX,_positionY), _speed);
            ArcherView archerView = new ArcherView(archerModel);
            ArcherController archerController = new ArcherController(_aiInput, mapController, archerModel, archerView, player);
            archerController.Manage();
        }
    }
}
