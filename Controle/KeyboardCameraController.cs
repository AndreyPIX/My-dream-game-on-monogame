using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace StrategyRTS.Controle
{
	public class KeyboardCameraController : KeyboardController
	{

		protected override void ProcessKeyAction(Keys key)
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
			puppetMap.Displacement(delta);
		}
	}
}
