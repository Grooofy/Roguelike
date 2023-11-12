using Enemy;
using Map;
using Player;

namespace GameLogic
{
    public class Game
    {
        private int _lvl = 0;
        private Maze _maze = new Maze();
        private MapController _mapController;
        private PlayerObject _player = new PlayerObject();
        private PlayerModel _playerModel;
        private Archer _archer = new Archer();
        private Warrior _warrior = new Warrior();
        private bool _isGameOver;

        public void Start()
        {
            Console.Clear();
            _lvl++;
            _mapController = _maze.CreateRandomSize();
            _playerModel = _player.CreateNewPlayer(_mapController);
            _player.Ended += Reload;
            _archer.CreateArchers(_mapController, _playerModel, 3);
            _warrior.CreateWarriors(_mapController, _playerModel, 5);
        }

        public void Update()
        {
            _player.Manage(_isGameOver, _mapController.GetExitPosition());
        }

        private void Reload()
        {
            _player.Ended -= Reload;
            Start();
        }
    }
}
