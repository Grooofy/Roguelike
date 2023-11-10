namespace Map
{
    public class MapController
    {
        private readonly MapModel _map;
        private readonly MapView _view;
        public readonly char[,] MapSize;

        public MapController(MapModel map, MapView view, int weight, int height)
        {
            _map = map;
            _view = view;
            MapSize = _map.Generate(height, weight);
        }

        public void Create()
        {
            _view.Show(MapSize);
        }
    }
}
