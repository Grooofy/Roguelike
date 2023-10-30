namespace Roguelike;

public class PlayerController
{
    private PlayerModel _playerModel;
    private PlayerView _playerView;

    public PlayerController()
    {
        _playerModel = new PlayerModel(5);
        _playerView = new PlayerView(_playerModel);
    }


    public void Update()
    {
        _playerView.Show(_playerModel.CurrentPosition);
        while (true)
        {
            var key = Console.ReadKey();
            _playerModel.Move(key);
        }
    }
}