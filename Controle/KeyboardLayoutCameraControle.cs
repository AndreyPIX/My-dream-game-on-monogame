using Microsoft.Xna.Framework.Input;

namespace StrategyRTS.Controle
{
	public class KeyboardLayoutCameraControle : KeyboardLayout
	{
		public KeyboardLayoutCameraControle()
		{
			AddBind(Keys.A, EnumKeyAction.MoveLeft);
			AddBind(Keys.W, EnumKeyAction.MoveUp);
			AddBind(Keys.D, EnumKeyAction.MoveRight);
			AddBind(Keys.S, EnumKeyAction.MoveDown);
		}
	}
}
