
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StrategyRTS.GameScenes
{
	public abstract class GameSceneBase
	{
		protected GameEngine engine;

		protected GameSceneBase(GameEngine engine)
		{
			this.engine = engine;
		}

		public abstract void LoadContent(ContentManager content);
		public abstract void Initialize();
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			engine.Draw(spriteBatch);
		}

	}
}
