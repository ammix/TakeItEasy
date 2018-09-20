using System.Drawing;

namespace TakeItEasy.View
{
	public struct Hexagon
	{
		public float Edge { get; }
		public PointF Center { get; }

		public Hexagon(float edge, PointF center)
		{
			Edge = edge;
			Center = center;
		}
	}
}