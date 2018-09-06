using System;
using System.Drawing;

namespace TakeItEasy.View
{
	public struct Hexagon
	{
		public float Edge { get; }
		public PointF Center { get; }
		public PointF[] Vertices { get; }

		public Hexagon(float edge, PointF center)
		{
			Edge = edge;
			Center = center;

			var a = Edge;
			var c = new SizeF(Center);

			var sqrt3 = (float)Math.Sqrt(3);
			var p1 = new PointF(a / 2f, a * sqrt3 / 2) + c;
			var p2 = new PointF(a, 0) + c;
			var p3 = new PointF(a / 2f, -a * sqrt3 / 2) + c;
			var p4 = new PointF(-a / 2f, -a * sqrt3 / 2) + c;
			var p5 = new PointF(-a, 0) + c;
			var p6 = new PointF(-a / 2f, a * sqrt3 / 2) + c;

			Vertices = new[] { p1, p2, p3, p4, p5, p6, p1 };
		}
	}
}