using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StrategyRTS.AnimationClasses;
using StrategyRTS.Experemental;
using StrategyRTS.Experemental.Controle;
using StrategyRTS.GameObjects;
using StrategyRTS.Shared;
using System;

namespace StrategyRTS
{
    public class Game1 : Game
	{
		private GraphicsDeviceManager graphics;
		private SpriteBatch spriteBatch;

		private Map map;

		private Texture2D textureWater;
		private Texture2D textureSand;
		private Texture2D textureGrass;
		private Texture2D textureStone;
		private Texture2D textureRock;

		private GameObject water;
		private GameObject sand;
		private GameObject grass;
		private GameObject stone;
		private GameObject rock;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
			graphics.PreferredBackBufferHeight = 1080;
			graphics.PreferredBackBufferWidth = 1920;
		}
		protected override void Initialize()
		{
			base.Initialize();

			water = new GameObject(textureWater);
			sand = new GameObject(textureSand);
			grass = new GameObject(textureGrass);
			stone = new GameObject(textureStone);
			rock = new GameObject(textureRock);

			map = new Map(256*4, 256 * 4);
			map.Scale = 0.1f;
			map.AddCell(water);
			map.AddCell(grass);
			map.AddCell(rock);
			map.CreateNoiseMap(256 * 4, 256 * 4, 8);
		}
		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			Globals.VideoCard = this.GraphicsDevice;
			textureWater = Content.Load<Texture2D>("png/Relief/Water");
			textureSand = Content.Load<Texture2D>("png/Relief/Sand");
			textureGrass = Content.Load<Texture2D>("png/Relief/Grass");
			textureStone = Content.Load<Texture2D>("png/Relief/Stone");
			textureRock = Content.Load<Texture2D>("png/Relief/Rock");
		}
		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			base.Update(gameTime);
		}
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);
			spriteBatch.Begin();
			map.Draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
