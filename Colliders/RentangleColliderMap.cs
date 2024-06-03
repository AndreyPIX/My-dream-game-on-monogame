
using Microsoft.Xna.Framework;
using StrategyRTS.GameObjects;

namespace StrategyRTS.Colliders
{
	public class RentangleColliderMap : RentangleCollider
	{
		public void SetMaster(Map master)
		{
			base.SetMaster(master);
			rectangle = new Rectangle(0, 0, master.Width, master.Height);
		}
		public override Rectangle GetBounds()
		{
			Rectangle rectangle = new Rectangle();
			rectangle.Width = (int)(rectangle.Width * master.Scale.X);
			rectangle.Height = (int)(rectangle.Height * master.Scale.Y);
			rectangle.X = (int)(master.Position.X - rectangle.Width / 2);
			rectangle.Y = (int)(master.Position.Y - rectangle.Height / 2);
			return rectangle;
		}
		private bool IntersectsLines(Rectangle rect1, Rectangle rect2)
		{
			return rect1.Left < rect2.Left || rect1.Right > rect2.Right || rect1.Top < rect2.Top || rect1.Bottom > rect2.Bottom;
		}
		public override bool IsCollision(BaseCollider collider)
		{
			Rectangle rect1 = this.GetBounds();
			Rectangle rect2 = collider.GetBounds();
			return IntersectsLines(rect1, rect2);
		}
	}
}
