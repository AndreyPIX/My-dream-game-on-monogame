using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StrategyRTS.Experemental.Controle
{
    public class RotateToTursor
    {
        public Vector2 MouseCursorCoordinates()
        {
            MouseState mouseState = Mouse.GetState();
            return new Vector2(mouseState.X, mouseState.Y);
        }
    }
}
