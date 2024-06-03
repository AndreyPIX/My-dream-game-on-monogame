
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.GameObjects;
using System.Drawing;

namespace StrategyRTS.Colliders
{
	public abstract class BaseCollider
	{
		protected GameObject master;
		public GameObject Master
		{
			get { return master; }
		}
		public abstract void Draw(SpriteBatch spriteBatch); // Для визуального тестирования
		public virtual void SetMaster(GameObject master)
		{
			this.master = master;
		}
		public abstract bool IsCollision(BaseCollider collider);
		public abstract Rectangle GetBounds();
	}
}
