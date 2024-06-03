
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StrategyRTS.Controle
{
	public class KeyboardController : BaseController
	{
		protected KeyboardLayout layout;
		public KeyboardController()
		{
			layout = new KeyboardLayout();
		}
		public KeyboardController(KeyboardLayout layout)
		{
			this.layout = layout;
		}
		protected virtual void ProcessKeyAction(Keys key)
		{
			Vector2 delta = new Vector2(0);
			int speed = 1;
			switch (layout.GetActionForKey(key))
			{
				case EnumKeyAction.None:
					break;
				case EnumKeyAction.MoveRight:
					delta.X = speed;
					break;
				case EnumKeyAction.MoveUp:
					delta.Y = -speed;
					break;
				case EnumKeyAction.MoveLeft:
					delta.X = -speed;
					break;
				case EnumKeyAction.MoveDown:
					delta.Y = speed;
					break;
			}
			puppet.Move(delta);
		}
		public override void Update(GameTime gameTime)
		{
			KeyboardState state = Keyboard.GetState();
			Keys[] keys = state.GetPressedKeys();
			foreach (Keys key in keys)
				ProcessKeyAction(key);
		}
	}
}
