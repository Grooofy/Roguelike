﻿using System.Numerics;
using Interfaces;
using Map;

namespace ParentObjects
{
    public class GameObjectController
    {
        private GameObjectView _gameObjectView;
        private Vector2 _startPosition;

        protected IInputSystem _inputSystem;
        protected MapController _mapController;
        protected  GameObjectModel _gameObjectModel;
        
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

        public virtual async void Manage()
        {
            await Task.Run(() => _gameObjectModel.Move(_inputSystem, _mapController));
        }
    }
}
