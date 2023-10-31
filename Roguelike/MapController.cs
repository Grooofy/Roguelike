namespace Roguelike
{
    public class MapController
    {
        private readonly MapModel _map;
        private readonly MapView _view;
        private char[,] _mapSize;

        public int SizeX => _mapSize.GetLength(1);
        public int SizeY => _mapSize.GetLength(0);

        public MapController(MapModel map, MapView view, int weight, int height)
        {
            _map = map;
            _view = view;
            _mapSize = new char[weight, height];
        }

        public void Create()
        {
            _mapSize = _map.Generate(SizeX, SizeY);
            _view.Show(_mapSize);
        }
    }
}
