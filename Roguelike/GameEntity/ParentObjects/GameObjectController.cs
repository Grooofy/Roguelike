using System.Numerics;
using Interfaces;
using Map;

namespace ParentObjects
{
    public class GameObjectController
    {
        private IInputSystem _inputSystem;
        private MapController _mapController;
        private  GameObjectModel _gameObjectModel;
        private GameObjectView _gameObjectView;
        private Vector2 _startPosition;

        public GameObjectController(IInputSystem inputSystem, MapController mapController, GameObjectModel gameObjectModel, GameObjectView gameObjectView)
        {
            _inputSystem = inputSystem;
            _mapController = mapController;
            _gameObjectModel = gameObjectModel;
            _gameObjectView = gameObjectView;
        }
        
        public void Create()
        {
            _gameObjectView.Show(_gameObjectModel.CurrentPosition, false);
        }

        public void Manage()
        {
            _gameObjectModel.Move(_inputSystem, _mapController);
        }
    }
}
