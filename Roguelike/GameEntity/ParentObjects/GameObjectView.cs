using System.Numerics;
using Map;
using Status;

namespace ParentObjects
{
    public class GameObjectView
    {
        private GameObjectModel _gameObjectModel;
        private Symbol _symbol;

        public GameObjectView(GameObjectModel gameObjectModel, Symbol symbol)
        {
            _gameObjectModel = gameObjectModel;
            _symbol = symbol;
            gameObjectModel.Moved += Show;
        }

        public void Show(Vector2 position, bool isMove)
        {
            WriteSymbol(position, _symbol);

            if (isMove)
                CleanCell(position);
        }

        private void CleanCell(Vector2 position)
        {
            WriteSymbol(_gameObjectModel.PreviousPosition, Symbol.CleanCell);
            Console.SetCursorPosition((int)position.X, (int)position.Y);
        }

        private void WriteSymbol(Vector2 cursorPosition, Symbol symbol)
        {
            Console.SetCursorPosition((int)cursorPosition.X, (int)cursorPosition.Y);
            Console.Write((char)symbol);
            Console.SetCursorPosition((int)cursorPosition.X, (int)cursorPosition.Y);
        }
    }
}
