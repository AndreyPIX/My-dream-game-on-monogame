
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.XInput;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using StrategyRTS.Menagers;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace StrategyRTS
{
    public class GameEngine : BaseManager<GameObject>
	{
		private List<BaseController> controllers;
		public GameEngine() : base()
		{
			controllers = new List<BaseController>();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
            foreach (var item in controllers)
            {
				item.Update(gameTime);
            }
        }

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}
