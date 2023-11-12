using System.Numerics;

namespace Map
{
    public class MapController
    {
        public int Weight { get; private set; }
        public int Height { get; private set; }
        
        private readonly MapModel _mapModel;
        private readonly MapView _view;
        private readonly char[,] _map;

        public MapController(MapModel mapModel, MapView view, int weight, int height)
        {
            Weight = weight;
            Height = height;
            _mapModel = mapModel;
            _view = view;
            _map = _mapModel.Generate(height, weight);
        }

        public Vector2 GetExitPosition()
        {
            return _mapModel.GetExitPosition();
        }
        
        public void RemoveWall(Vector2 position)
        {
            _map[(int)position.Y, (int)position.X] = (char)Symbol.CleanCell;
        }
        
        public char GetSymbolMap(Vector2 position)
        {
            return _map[(int)position.Y, (int)position.X];
        } 

        public void Create()
        {
            _view.Show(_map);
        }
    }
}
