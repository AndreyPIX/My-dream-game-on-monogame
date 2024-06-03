
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.Colliders;

namespace StrategyRTS.GameObjects
{
    public class GameObject
    {
		protected BaseCollider collider;
		protected Rectangle? sourseRentangle;
		protected Texture2D texture;
		protected Vector2 lastMove;
		protected Vector2 position;
        protected Vector2 velocity;
		protected Vector2 origin;
		protected Vector2 scale;
		protected float angle;
		protected float rotationVelocity;

		public BaseCollider Collider
		{
			get
			{
				return collider;
			}
		}
		public Texture2D Texture
        {
			get { return texture; }
		}
		public Vector2 LastMove
		{
			get { return lastMove; }
		}
		public Vector2 Position
        {
            get
            {
                return position;
            }
        }
		public Vector2 Scale
		{
            get
            {
                return scale;
            }
			set
			{
				scale = value;
			}
		}
		public float Angle
		{
			get { return angle; }
		}
		public bool HasCollider
		{
			get
			{
				return collider != null;
			}
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
