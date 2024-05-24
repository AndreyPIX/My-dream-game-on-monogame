
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using StrategyRTS.Experemental;
using StrategyRTS.GameObjects;

namespace StrategyRTS.GameScenes
{
	public class GameScene1 : GameSceneBase
	{
		private Texture2D textureWater;
		private Texture2D textureSand;
		private Texture2D textureGrass;
		private Texture2D textureStone;
		private Texture2D textureRock;

		public GameScene1(GameEngine engine) : base(engine)
		{

		}

		public override void Initialize()
		{
			GameObject water = new GameObject(textureWater);
			GameObject sand = new GameObject(textureSand);
			GameObject grass = new GameObject(textureGrass);
			GameObject stone = new GameObject(textureStone);
			GameObject rock = new GameObject(textureRock);

			Map map = new Map(256 * 4, 256 * 4);
			map.Scale = 1f;
			map.AddCell(water);
			map.AddCell(grass);
			map.AddCell(rock);
			map.CreateNoiseMap(256 * 4, 256 * 4, 8);

			engine.Add(water);
			engine.Add(sand);
			engine.Add(grass);
			engine.Add(stone);
			engine.Add(rock);
			engine.Add(map);
		}

		public override void LoadContent(ContentManager content)
		{
			textureWater = content.Load<Texture2D>("png/Relief/Water");
			textureSand = content.Load<Texture2D>("png/Relief/Sand");
			textureGrass = content.Load<Texture2D>("png/Relief/Grass");
			textureStone = content.Load<Texture2D>("png/Relief/Stone");
			textureRock = content.Load<Texture2D>("png/Relief/Rock");
		}

		public override void Draw(SpriteBatch spriteBatch)
		{
			base.Draw(spriteBatch);
		}
	}
}
