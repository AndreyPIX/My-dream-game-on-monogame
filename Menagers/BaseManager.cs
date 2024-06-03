
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.GameObjects;
using System.Collections.Generic;

namespace StrategyRTS.Menagers
{
	public class BaseManager<T> where T : GameObject
	{
		protected List<T> list;
		public BaseManager()
		{
			list = new List<T>();
		}
		public virtual void Add(T obj)
		{
			list.Add(obj);
		}
		public virtual void Update(GameTime gameTime)
		{
			foreach (var item in list)
				item.Update(gameTime);
		}
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			foreach (var item in list)
				item.Draw(spriteBatch);
		}
	}
}
