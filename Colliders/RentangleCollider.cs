
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.GameObjects;
using System.Drawing;

namespace StrategyRTS.Colliders
{
	public class RentangleCollider : BaseCollider
	{
		protected Rectangle rectangle;
		public override void SetMaster(GameObject master)
		{
			base.SetMaster(master);
		}
		public override void Draw(SpriteBatch spriteBatch)
		{
			
		}
		public override Rectangle GetBounds()
		{
			Rectangle rectangle = new Rectangle();
			return rectangle;
		}
		public override bool IsCollision(BaseCollider collider)
		{
			return false;
		}
	}
}
