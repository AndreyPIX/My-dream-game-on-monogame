using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StrategyRTS.GameObjects;
using System.ComponentModel;
namespace StrategyRTS.AnimationClasses
{
    public class Animation : GameObject
    {
        protected int frameStart;
        protected int frameEnd;
        protected int frameDuration;
        protected double frameElapsedMs = 0;
        protected int columns;
        protected int rows;
        protected int frameCount;
        protected int actionFrameNumber = 0;
        protected int frameWidth;
        protected int frameHeight;
        protected Rectangle frameRactangle;
        public Animation(Texture2D texture, int columns, int rows) : base(texture)
        {
            this.columns = columns;
            this.rows = rows;
            frameWidth = texture.Width / columns;
            frameHeight = texture.Height / rows;
            frameRactangle = new Rectangle(0, 0, frameWidth, frameHeight);
            frameCount = rows * columns;
            origin = new Vector2(texture.Width / columns / 2, texture.Height / rows / 2);
            frameDuration = 100;
            frameStart = 0;
            frameEnd = frameCount;
        }
        public void SetAnimation(int start, int end)
        {
            frameStart = start;
            frameEnd = end;
        }
        protected void ApplyAnimationCycle()
        {
            if (actionFrameNumber >= frameEnd)
                actionFrameNumber = frameStart;
        }
        protected void SwitchAnimationFrame()
        {
            int actionColumns = actionFrameNumber % columns;
            int actionRows = actionFrameNumber / columns;
            frameRactangle.X = actionColumns * frameWidth;
            frameRactangle.Y = actionRows * frameHeight;
        }
        public override void Update(GameTime gameTime)
        {
            frameElapsedMs += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (frameElapsedMs > frameDuration)
            {
                actionFrameNumber++;
                ApplyAnimationCycle();
                SwitchAnimationFrame();
                frameElapsedMs = 0;
            }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, frameRactangle, Color.White, angle, origin, scale, SpriteEffects.None, 1);
        }
    }
}
