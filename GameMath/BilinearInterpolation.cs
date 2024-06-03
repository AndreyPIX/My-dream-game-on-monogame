
namespace StrategyRTS.GameMath
{
	public class BilinearInterpolation
	{
		public static float BilinearInterpolationFormula(float[,] heights, int width, int height, int x, int y, int shift)
		{
			float z1 = heights[y / shift * shift, x / shift * shift];
			float z2 = heights[y / shift * shift, (x / shift * shift + shift) % width];
			float z3 = heights[(y / shift * shift + shift) % height, x / shift * shift];
			float z4 = heights[(y / shift * shift + shift) % height, (x / shift * shift + shift) % width];
			float formX1 = InterpolateFormula1(x, shift, width);
			float formX2 = InterpolateFormula2(x, shift, width);
			float zx1 = formX1 * z1 + formX2 * z2;
			float zx2 = formX1 * z3 + formX2 * z4;
			float formY1 = InterpolateFormula1(y, shift, width);
			float formY2 = InterpolateFormula2(y, shift, width);
			float zy1 = formY1 * zx1 + formY2 * zx2;
			return zy1;
		}
		public static float InterpolateFormula1(int focalPoint, int scale, int distance)
		{
			return (float)((focalPoint / scale * scale + scale) % distance - focalPoint)
						/ ((focalPoint / scale * scale + scale) % distance - focalPoint / scale * scale);
		}
		public static float InterpolateFormula2(int focalPoint, int scale, int distance)
		{
			return (float)(focalPoint - focalPoint / scale * scale)
						/ ((focalPoint / scale * scale + scale) % distance - focalPoint / scale * scale);
		}
	}
}
