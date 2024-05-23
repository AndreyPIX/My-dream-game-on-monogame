namespace StrategyRTS.GameMath
{
	public class BilinearInterpolation
	{
		public static float InterpolateForm1(int focalPoint, int scale, int distance)
		{
			return (float)((focalPoint / scale * scale + scale) % distance - focalPoint)
						/ ((focalPoint / scale * scale + scale) % distance - focalPoint / scale * scale);
		}
		public static float InterpolateForm2(int focalPoint, int scale, int distance)
		{
			return (float)(focalPoint - focalPoint / scale * scale)
						/ ((focalPoint / scale * scale + scale) % distance - focalPoint / scale * scale);
		}
	}
}
