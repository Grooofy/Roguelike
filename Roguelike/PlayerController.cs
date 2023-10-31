using System.Numerics;

namespace Roguelike;

public class PlayerController
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;
    private Vector2 _startPosition = new Vector2(1, 0);

    public PlayerController()
    {
        _playerModel = new PlayerModel(5, _startPosition);
        _playerView = new PlayerView(_playerModel);
    }


    public void Update()
    {
        _playerView.Show(_startPosition);
        
        while (_playerModel.IsDie == false)
        {
            var key = Console.ReadKey();
            _playerModel.TryMove(key, 10,10);
            
        }
    }
}