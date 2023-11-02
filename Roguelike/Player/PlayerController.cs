using System.Numerics;

namespace Roguelike;

public class PlayerController
{
    private MapController _mapController;
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private Vector2 _startPosition = new Vector2(1, 1);
    

    public PlayerController(MapController mapController)
    {
        _mapController = mapController;
        _playerModel = new PlayerModel(5, _startPosition);
        _playerView = new PlayerView(_playerModel);
    }


    public void Update()
    {
        _playerView.Show(_startPosition);
        
        while (_playerModel.IsDie == false)
        {
            var key = Console.ReadKey();
            _playerModel.TryMove(key, _mapController.SizeX,_mapController.SizeY); 
        }
    }
}