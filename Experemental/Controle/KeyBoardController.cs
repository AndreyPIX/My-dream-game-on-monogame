using Microsoft.Xna.Framework;
using System;
using StrategyRTS.Controle;

namespace StrategyRTS.Experemental.Controle
{
	public class KeyBoardController : BaseController
	{
		/*
        protected KeyboardLayout layout;
        public KeyBoardController()
        {
            layout = new KeyBoardLayoutTankControle();
        }
        public KeyBoardController(KeyboardLayout layout)
        {
            this.layout = layout;
        }
        public void ChangeLayout(KeyboardLayout layout)
        {
            this.layout = layout;
        }
        public virtual Vector2 ProcessKeyAction(EnumKeyAction keyAction, Vector2 delta)
        {
            switch (keyAction)
            {
                case EnumKeyAction.None:
                    break;
                case EnumKeyAction.MoveLeft:
                    delta.X = -1;
                    break;
                case EnumKeyAction.MoveRight:
                    delta.X = 1;
                    break;
                case EnumKeyAction.MoveDown:
                    delta.Y = -1;
                    break;
                case EnumKeyAction.MoveBackward:
                    delta.Y = 1;
                    break;
                case EnumKeyAction.Attack:
                    break;
                default:
                    break;
            }
            return delta;
        }
        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            Vector2 delta = new Vector2(0);
            Keys[] pressedKeys = state.GetPressedKeys();
            foreach (var k in pressedKeys)
            {
                EnumKeyAction keyAction = layout.GetActionForKey(k);
                delta = ProcessKeyAction(keyAction, delta);
            }
            puppet.Move(delta);
        }
        */
		public override void Update(GameTime gameTime)
		{
			throw new NotImplementedException();
		}
	}
}
