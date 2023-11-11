// See https://aka.ms/new-console-template for more information

using System.Numerics;
using Enemy;
using Interfaces;
using Map;
using Player;
using Status;


MapModel mapModel = new MapModel();
MapView mapView = new MapView();
MapController mapController = new MapController(mapModel, mapView, 100, 15);
mapController.Create();
KeyBoardInput _key = new KeyBoardInput();
AiInput _aiInput = new AiInput();
PlayerModel _player = new PlayerModel(5, 5, new Vector2(1, 0));
PlayerView _playerView = new PlayerView(_player);
WarriorModel warriorModel = new WarriorModel(new Vector2(3,3), _player);
WarriorView warriorView = new WarriorView(warriorModel);
PlayerController playerController = new PlayerController(_key, mapController, _player, _playerView);

WarriorController warriorController = new WarriorController(_aiInput, mapController, warriorModel, warriorView);
PlayerConsoleStatus playerConsoleStatus = new PlayerConsoleStatus(100, _player);
playerConsoleStatus.ShowInfoHealth(_player.Health);
playerConsoleStatus.ShowInfoPickaxe(5);
playerController.Create();
warriorController.Create();



Play1();
PlayPlayer();

void PlayEnemy()
{
    while (true)
    {
        Thread.Sleep(300);
        warriorController.Manage();
    }
}

void PlayPlayer()
{
    while (true)
    {
        playerController.Manage();
    }
}

async void Play1()
{
    await Task.Run(PlayEnemy);
}



Console.ReadKey();
