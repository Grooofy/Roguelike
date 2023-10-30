using System.Numerics;

namespace Roguelike;

public class PlayerView
{
    private PlayerModel _playerModel;
   

    public PlayerView(PlayerModel playerModel)
    {
        _playerModel = playerModel;
        _playerModel.Moved += Show;
    }

    public void Show(Vector2 position)
    {
        Console.SetCursorPosition((int)position.X, (int)position.Y);
        Console.Write((char)Symbol.Player);
        Console.SetCursorPosition((int)_playerModel.PreviousPosition.X, (int)_playerModel.PreviousPosition.Y);
        Console.Write((char)Symbol.CleanCell);
    }
}