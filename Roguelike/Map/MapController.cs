using System.Numerics;

namespace Map
{
    public class MapController
    {
        private readonly MapModel _mapModel;
        private readonly MapView _view;
        private readonly char[,] _map;

        public MapController(MapModel mapModel, MapView view, int weight, int height)
        {
            _mapModel = mapModel;
            _view = view;
            _map = _mapModel.Generate(height, weight);
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
