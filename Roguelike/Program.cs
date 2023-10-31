// See https://aka.ms/new-console-template for more information

using Roguelike;

MapModel mapModel = new MapModel();
MapView mapView = new MapView();
MapController mapController = new MapController(mapModel, mapView, 100, 15);
mapController.Create();
PlayerController playerController = new PlayerController(mapController);
playerController.Update();

Console.ReadKey();



