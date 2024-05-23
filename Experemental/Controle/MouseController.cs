using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StrategyRTS.Controle;

namespace StrategyRTS.Experemental.Controle
{
    public abstract class MouseController : BaseController
    {
        private Vector2 cursorPosition;
        MouseState state = new MouseState();
        public override void Update(GameTime gameTime)
        {
            // координаты курсора
            cursorPosition.X = state.X;
            cursorPosition.Y = state.Y;
            //if (puppet.Angle > )
            // Angle = arccos((X1 - X0/R)
            // 
            //
            //
            //
        }
    }
}
