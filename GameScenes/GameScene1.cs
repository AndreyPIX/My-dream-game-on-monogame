using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

			Map map = new();
			map.Scale = new Vector2(0.01f);
			map.SetSizeMap(256 * 2, 256 * 2);
			map.AddCell(water);
			map.AddCell(sand);
			map.AddCell(grass);
			map.AddCell(rock);
			map.CreateMap(7);

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
