
using Microsoft.Xna.Framework.Input;

namespace StrategyRTS.Controle
{
	public class KeyboardLayoutCameraControle : KeyboardLayout
	{
		public KeyboardLayoutCameraControle()
		{
			AddBind(Keys.Left, EnumKeyAction.MoveLeft);
			AddBind(Keys.Up, EnumKeyAction.MoveUp);
			AddBind(Keys.Right, EnumKeyAction.MoveRight);
			AddBind(Keys.Down, EnumKeyAction.MoveDown);
		}
	}
}
