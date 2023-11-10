using System.Numerics;
using Map;
using Player.Interfaces;

namespace Player;

public class PlayerController
{
    private KeyBoardInput _keyBoardInput = new KeyBoardInput();
    private MapController _mapController;
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private Vector2 _startPosition = new Vector2(1, 0);
    

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
            _playerModel.Move(_keyBoardInput, _mapController.MapSize); 
        }
    }
}