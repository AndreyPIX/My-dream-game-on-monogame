
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Colliders;
using StrategyRTS.Controle;
using StrategyRTS.GameObjects;
using StrategyRTS.Menagers;
using System.Collections.Generic;

namespace StrategyRTS
{
    public class GameEngine : BaseManager<GameObject>
	{
		private List<BaseController> controllers;
		private List<BaseCollider> colliders;
		public GameEngine() : base()
		{
			controllers = new List<BaseController>();
			colliders = new List<BaseCollider>();
		}
		public override void Add(GameObject obj)
		{
			base.Add(obj);
			if (obj.HasCollider)
				colliders.Add(obj.Collider);
		}
		public void Add(BaseController controller)
		{
			controllers.Add(controller);
		}
		private void CheckCollisions()
		{
			for (int i = 0;  i < colliders.Count; i++)
			{
				for (int j = 0; j <  colliders.Count; j++)
				{
					/*bool hasCollison = 
					if (i == j) continue;
					if (HasCol)*/
				}
			}
		}
		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime);
            foreach (var item in controllers)
				item.Update(gameTime);
        }
		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}
