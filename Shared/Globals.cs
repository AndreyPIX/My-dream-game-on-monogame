using Microsoft.Xna.Framework.Graphics;
using StrategyRTS.ProceduralGeneration;
namespace StrategyRTS.Shared
{
    public static class Globals
    {
        /// <summary>
        /// Глобальная сылка на виде карту
        /// </summary>
        public static GraphicsDevice VideoCard { get; set; }

        private static Texture2D textureBullet;
        public static Texture2D TextureBullet
        {
            get 
            {
                if (textureBullet == null)
                {
                    textureBullet = TextureGenerator.CreateTextureBullet();
                }
                return textureBullet;
            }
        }

		private static Texture2D textureWhiteNoise;
		public static Texture2D TextureWhiteNoise(int height, int width, int extension)
        {
			if (textureWhiteNoise == null)
			{
				textureWhiteNoise = TextureGenerator.CreateTextureWhiteNoise(height, width, extension);
			}
			return textureWhiteNoise;
		}

		private static Texture2D textureWhiteNoiseBilinearlyInterpolated;
		public static Texture2D TextureWhiteNoiseBilinearlyInterpolated(int height, int width, int extension)
		{
			if (textureWhiteNoiseBilinearlyInterpolated == null)
			{
				textureWhiteNoiseBilinearlyInterpolated = TextureGenerator.CreateTextureWhiteNoiseBilinearlyInterpolated(height, width, extension);
			}
			return textureWhiteNoiseBilinearlyInterpolated;
		}

		private static Texture2D texturePerlinNoise;
		public static Texture2D TexturePerlinNoise(int height, int width)
        {
			if (texturePerlinNoise == null)
			{
				texturePerlinNoise = TextureGenerator.CreateTexturePerlinNoise(height, width);
			}
			return texturePerlinNoise;
		}

        private static Texture2D texturePerlinNoiseBilinearlyInterpolated;
		public static Texture2D TexturePerlinNoiseBilinearlyInterpolated(int height, int width)
        {
            if (texturePerlinNoiseBilinearlyInterpolated == null)
            {
				texturePerlinNoiseBilinearlyInterpolated = TextureGenerator.CreateTexturePerlinNoiseBilinearlyInterpolated(height, width);
            }
			return texturePerlinNoiseBilinearlyInterpolated;
		}


	}
}
