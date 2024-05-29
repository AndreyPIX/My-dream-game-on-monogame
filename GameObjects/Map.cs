using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using StrategyRTS.ProceduralGeneration;
using System.Collections.Generic;
namespace StrategyRTS.GameObjects
{
    public class Map : GameObject
    {
		private List<GameObject> list = new List<GameObject>();
		private int size = 256;
        private int[,,] map;

		public void LoadMap(int[,] map)
		{
			this.map = new int[map.GetLength(0), map.GetLength(1), 2];
			for (int x = 0; x < map.GetLength(0); x++)
			{
				for (int y = 0; y < map.GetLength(1); y++)
				{
					this.map[y, x, 0] = map[x, y];
					if (map[y, x] == 0)
						this.map[y, x, 1] = 0;
					if (map[y, x] == 1)
						this.map[y, x, 1] = 2;
				}
			}
		}
        public void SetSizeMap(int width, int height)
        {
            map = new int[height, width, 2]; // 0 - индекс хранит глубину, второй хранит индекс текстуры
		}
        public void AddCell(GameObject gameObjects)
        {
            list.Add(gameObjects);
        }
        private void LayerGenerate(int countOctaves)
        {
			float[,] noise = NoisesGenerator.GeneratePerlinNoiseBilinearlyInterpolated(map.GetLength(0), map.GetLength(1), countOctaves);
			for (int y = 0; y < map.GetLength(0); y++)
			{
				for (int x = 0; x < map.GetLength(1); x++)
				{
					if (noise[y, x] < 0.34)
						map[y, x, 0] = 0;
					else if (noise[y, x] < 0.6)
						map[y, x, 0] = 1;
					else
						map[y, x, 0] = 2;
				}
			}
		}
		private void Smoothing(int changingLayer, int changeLayer)
		{
			int[,,] tempMap = map;
			for (int y = 0; y < map.GetLength(0); y++)
			{
				for (int x = 0; x < map.GetLength(1); x++)
				{
					if (map[y, x, 0] == changingLayer)
					{
						int countCell = 0;
						if (x - 1 != -1 && map[y, x - 1, 0] == changeLayer)
							countCell += 1;
						if (x + 1 != map.GetLength(1) && map[y, x + 1, 0] == changeLayer)
							countCell += 1;
						if (y - 1 != -1 && map[y - 1, x, 0] == changeLayer)
							countCell += 1;
						if (y + 1 != map.GetLength(0) && map[y + 1, x, 0] == changeLayer)
							countCell += 1;
						if (countCell > 2)
							tempMap[y, x, 0] = changeLayer;
					}
				}
			}
			map = tempMap;
		}
		private void ShoreGeneration()
        {
			for (int y = 0; y < map.GetLength(0); y++)
			{
				for (int x = 0; x < map.GetLength(1); x++)
				{
					if (map[y, x, 1] != 0 && map[y, x, 1] != 3)
					{
						for (int y0 = -1; y0 < 2; y0++)
						{
							if (y + y0 == -1)
								continue;
							else if (y + y0 == map.GetLength(0))
								continue;
							for (int x0 = -1; x0 < 2; x0++)
							{
								if (x + x0 == -1)
									continue;
								else if (x + x0 == map.GetLength(1))
									continue;
								if (map[y + y0, x + x0, 1] == 0)
								{
									map[y, x, 1] = 1;
									break;
								}
							}
						}
					}
				}
			}
		}
		private void Superimposition()
		{
			for (int y = 0; y < map.GetLength(0); y++)
			{
				for (int x = 0; x < map.GetLength(1); x++)
				{
					if (map[y, x, 0] == 0)
						map[y, x, 1] = 0; // вода
					else if (map[y, x, 0] == 1)
						map[y, x, 1] = 2; // трава
					else
						map[y, x, 1] = 3; // скала
				}
			}
		}
		public void CreateMap(int countOctaves = 5)
        {
			LayerGenerate(countOctaves);
			Smoothing(1, 0);
			Smoothing(0, 1);
			Smoothing(2, 1);
			Smoothing(1, 2);
			Superimposition();
			ShoreGeneration();
		}
        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    list[map[y, x, 1]].SetPosition(new Vector2(scale.X * size * x + position.X, scale.Y * size * y + position.Y));
                    list[map[y, x, 1]].Scale = scale;
                    list[map[y, x, 1]].Draw(spriteBatch);
                }
            }
        }
		/*
        вода   id: 0
        песок  id: 1
        трава  id: 2
        камень id: -
        скала  id: 3
        */
	}
}
