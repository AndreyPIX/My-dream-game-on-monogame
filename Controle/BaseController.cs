using Microsoft.Xna.Framework;
using StrategyRTS.Experemental;
using StrategyRTS.GameObjects;


namespace StrategyRTS.Controle
{
    public abstract class BaseController
    {
        protected GameObject puppet;
		protected Map puppetMap;
		public void Attach(GameObject puppet)
		{
			this.puppet = puppet;
		}
		public void Attach(Map puppetMap)
		{
			this.puppetMap = puppetMap;
		}
		public abstract void Update(GameTime gameTime);
	}
}
