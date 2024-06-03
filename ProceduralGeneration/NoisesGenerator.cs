
using SharpDX;
using StrategyRTS.GameMath;
using System;

namespace StrategyRTS.ProceduralGeneration
{
    public class NoisesGenerator
    {
        public static float[,] GenerateWhiteNoise(int height, int width, int extension)
        {
            Random random = new Random();
            int scale = 1 << extension;
            float[,] heights = new float[height, width];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x % scale == 0 && y % scale == 0)
                        heights[y, x] = random.NextSingle();
                    heights[y, x] = heights[y / scale * scale, x / scale * scale];
                }
            }
            return heights;
        }
        public static float[,] GenerateWhiteNoiseBilinearlyInterpolated(int height, int width, int extension)
        {
            Random random = new Random();
            int scale = 1 << extension;
            float[,] heights = new float[height, width];
            for (int y = 0; y < height / scale; y++)
            {
                for (int x = 0; x < width / scale; x++)
                    heights[y * scale, x * scale] = random.NextFloat(-0.25f, 1.25f);
            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    heights[y, x] = BilinearInterpolation.BilinearInterpolationFormula(heights, width, height, x, y, scale);
            }
			return heights;
        }
		public static float[,] GeneratePerlinNoise(int height, int width, int octaveNumber)
        {
            float[,] heights = new float[height, width];
            for (int extension = 0; extension < octaveNumber; extension++)
            {
                float[,] tempHeights = GenerateWhiteNoise(height, width, extension);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                        heights[y, x] += tempHeights[y, x];
                }
            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                    heights[y, x] /= octaveNumber;
            }
			return heights;
        }
        public static float[,] GeneratePerlinNoiseBilinearlyInterpolated(int height, int width, int octaveNumber, int minExtension = 0, int maxExtension = 4)
        {
            float[,] heights = new float[height, width];
            for (int extension = 0; extension < octaveNumber; extension++)
            {
                float[,] tempHeights = GenerateWhiteNoiseBilinearlyInterpolated(height, width, extension);
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                        heights[y, x] += tempHeights[y, x];
                }
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                    heights[i, j] /= octaveNumber;
            }
			for (int y = 0; y < height; y++)
			{
				for (int x = 0; x < width; x++)
				{
					if (heights[y, x] < 0)
						heights[y, x] = 0f;
					else if (heights[y, x] > 1f)
						heights[y, x] = 1f;
				}
			}
			return heights;
        }
    }
}
