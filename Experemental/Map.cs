using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.GameObjects;
using StrategyRTS.ProceduralGeneration;
using System.Collections.Generic;
namespace StrategyRTS.Experemental
{
    public class Map
    {
        private float scale = 1;
        public float Scale
        { 
            get { return scale; }
            set { scale = value; }
        }
        private int size = 256;
		private int height = 256;
		private int width = 256;
        private Vector2 position;
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
		private List<GameObject> layers = new List<GameObject>();
        private int[,] map;

		public Map(int width, int height)
		{
			this.width = width;
			this.height = height;
			map = new int[height, width];
		}

		public void Displacement(Vector2 delta)
        {
            position += delta;
		}
		public void AddCell(GameObject gameObjects)
        {
			layers.Add(gameObjects);
		}
        public void CreateNoiseMap(int width, int height, int countOctaves)
        {
			float[,] noise = NoisesGenerator.GeneratePerlinNoiseBilinearlyInterpolated(height, width, countOctaves);
			for (int y = 0; y < height; y++)
			{
                for (int x = 0; x < width; x++)
                {
                    if (noise[y, x] < 0.4)
                        map[y, x] = 0;
                    else if (noise[y, x] < 0.6)
                        map[y, x] = 1;
                    else
                        map[y, x] = 2;
                }
			}
            //map = GeneratorWorld.DepthSmoothing(map);
		}

        
        public void LoadMap(int[,] array, int x = 0)
        {
            position = new Vector2(x, 0); 
            height = array.GetLength(0);
            width = array.GetLength(1);
            map = array;
		}
		public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
                    layers[map[y, x]].SetPosition(new Vector2(scale * size * x + position.X, scale * size * y + position.Y));
                    layers[map[y, x]].Scale = new Vector2(scale);
					layers[map[y, x]].Draw(spriteBatch);
				}
			}
		}
	}
}
