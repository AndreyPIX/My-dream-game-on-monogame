
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Drawing;

namespace StrategyRTS.GameScenes
{
	public abstract class GameSceneBase
	{
		protected GameEngine engine;
		protected GraphicsDeviceManager graphics;
		protected GameSceneBase(GameEngine engine, GraphicsDeviceManager graphics)
		{
			this.engine = engine;
			this.graphics = graphics;
		}
		public abstract void LoadContent(ContentManager content);
		public abstract void Initialize();
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			engine.Draw(spriteBatch);
		}
	}
}
