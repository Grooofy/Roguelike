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
        WriteSymbol(position, Symbol.Player);
    }

    public void CleanCell(Vector2 position)
    {
        WriteSymbol(_playerModel.PreviousPosition, Symbol.CleanCell);
        Console.SetCursorPosition((int)position.X, (int)position.Y);
    }

    private void WriteSymbol(Vector2 cursorPosition, Symbol symbol)
    {
        Console.SetCursorPosition((int)cursorPosition.X, (int)cursorPosition.Y);
        Console.Write((char)symbol);
    }
}