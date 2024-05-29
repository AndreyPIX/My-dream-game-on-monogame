
using Microsoft.Xna.Framework;
using StrategyRTS.GameObjects;

namespace StrategyRTS.Controle
{
    public abstract class BaseController
    {
        protected GameObject puppet;
		public void Attach(GameObject puppet)
		{
			this.puppet = puppet;
		}
		public abstract void Update(GameTime gameTime);
	}
}
