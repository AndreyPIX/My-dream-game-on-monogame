using Microsoft.Xna.Framework;
using StrategyRTS.GameMath;
using System;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;

namespace StrategyRTS.ProceduralGeneration
{
    public class NoisesGenerator
    {
        /*
		float z1 = tempHeights[y * scale, x * scale];
		float z2 = tempHeights[y * scale, (x + 1) * scale % width];
		float z3 = tempHeights[(y + 1) * scale % height, x * scale];
		float z4 = tempHeights[(y + 1) * scale % height, (x + 1) * scale % width];
		for (int y1 = scale * y; y1 < scale * (y + 1) ; y1++)
		{
			for (int x1 = scale * x; x1 < scale * (x + 1); x1++)
			{
				float zx1 = (x1 - x * scale) / ((x + 1) * scale - x * scale) * (z1 * z2);   // ( X - Z1x ) / (Z2x - Z1x)
				float zx2 = (x1 - x * scale) / ((x + 1) * scale - x * scale) * (z3 * z4);
				float result = (y1 - y * scale) / ((y + 1) * scale - y * scale) * (zx1 * zx2);
				tempHeights[x1, y1] = result;
			}
		} 
		*/
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
                    heights[y * scale, x * scale] = random.NextSingle();
            }
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    float z1 = heights[y / scale * scale, x / scale * scale];
                    float z2 = heights[y / scale * scale, (x / scale * scale + scale) % width];
                    float z3 = heights[(y / scale * scale + scale) % height, x / scale * scale];
                    float z4 = heights[(y / scale * scale + scale) % height, (x / scale * scale + scale) % width];
                    float formX1 = BilinearInterpolation.InterpolateForm1(x, scale, width);
                    float formX2 = BilinearInterpolation.InterpolateForm2(x, scale, width);
                    float zx1 = formX1 * z1 + formX2 * z2;
                    float zx2 = formX1 * z3 + formX2 * z4;
                    float formY1 = BilinearInterpolation.InterpolateForm1(y, scale, width);
                    float formY2 = BilinearInterpolation.InterpolateForm2(y, scale, width);
                    float zy1 = formY1 * zx1 + formY2 * zx2;
                    heights[y, x] = zy1;
                }
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
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                    heights[i, j] /= octaveNumber;
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
            return heights;
        }
    }
}
