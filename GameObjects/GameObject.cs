using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace StrategyRTS.GameObjects
{
    public class GameObject
    {
		protected Rectangle? sourseRentangle;
		protected Texture2D texture;
		protected Vector2 position;
        protected Vector2 velocity;
		protected Vector2 origin;
		protected Vector2 scale;
		protected float angle;
		protected float rotationVelocity;

		public Vector2 Scale
		{
			set
			{
				scale = value;
			}
		}
		public float Angle
		{
			get { return angle; }
		}
		
        public GameObject()
        {
            position = new Vector2(0);
            sourseRentangle = null;
            angle = 0;
            origin = new Vector2(0);
            scale = new Vector2(1);
        }
        public GameObject(Texture2D texture) : this()
        {
            this.texture = texture;
        }

        public void Move(Vector2 delta)
        {
            position += delta;
		}
        public void SetPosition(Vector2 position)
        {
            this.position = position;
        }
		public virtual void Update(GameTime gameTime) 
        {

        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, sourseRentangle, Color.White, angle, origin, scale, SpriteEffects.None, 1);
        }
    }
}
