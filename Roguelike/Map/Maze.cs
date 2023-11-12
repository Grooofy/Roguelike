namespace Map
{
    public class Maze
    {
        private int _maxWeight = 100;
        private int _minWeight = 20;
        private int _maxHeight = 30;
        private int _minHeight = 10;
        private Random _random = new Random();


        public MapController CreateRandomSize()
        {
            int weight = _random.Next(_minWeight, _maxWeight);
            int height = _random.Next(_minHeight, _maxHeight);

            MapController mapController = CreateMap(weight, height);
            return mapController;
        }

        private MapController CreateMap(int weight, int height)
        {
            MapModel mapModel = new MapModel();
            MapView mapView = new MapView();
            MapController mapController = new MapController(mapModel, mapView, weight, height);
            mapController.Create();
            return mapController;
        }
    }
}
