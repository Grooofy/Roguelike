namespace Roguelike
{
    public class MapController
    {
        private readonly MapModel _map;
        private readonly MapView _view;
        private char[,] _mapSize;

        public MapController(MapModel map, MapView view, int weight, int hight)
        {
            _map = map;
            _view = view;
            _mapSize = new char[weight, hight];
        }

        public void Create()
        {
            _mapSize = _map.Generate(_mapSize.GetLength(1), _mapSize.GetLength(0));
            _view.Show(_mapSize);
        }
    }
}
