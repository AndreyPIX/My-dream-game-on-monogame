using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Controle;
using StrategyRTS.Experemental;
using StrategyRTS.GameObjects;
using StrategyRTS.Menagers;
using System.Collections.Generic;

namespace StrategyRTS
{
	public class GameEngine : BaseManager<GameObject>
	{
		protected List<Map> maps;

		public GameEngine() : base()
		{
			maps = new List<Map>();
		}

		public void Add(Map map)
		{
			maps.Add(map);
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);

			foreach (Map map in maps)
			{
				map.Draw(spriteBatch);
			}
		}
	}
}
