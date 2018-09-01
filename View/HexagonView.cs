using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy
{
	public struct HexagonView
	{
		private static readonly float sqrt3 = (float) Math.Sqrt(3);

		public float Edge { get; set; }
		public PointF Center { get; set; }
		public Color BorderColor { get; set; }
		public Color Color { get; set; }
		public float BorderThickness { get; set; } // ratio border to edge
		public GraphicsPath GraphicsPath { get; }

		public HexagonView(float edge, PointF center)
		{
			Edge = edge;
			Center = center;
			BorderColor = Color.Black;
			Color = Color.White;
			BorderThickness = 0.01f;

			var c = new SizeF(Center);

			var p1 = new PointF(Edge / 2f, Edge * sqrt3 / 2) + c;
			var p2 = new PointF(Edge, 0) + c;
			var p3 = new PointF(Edge / 2f, -Edge * sqrt3 / 2) + c;
			var p4 = new PointF(-Edge / 2f, -Edge * sqrt3 / 2) + c;
			var p5 = new PointF(-Edge, 0) + c;
			var p6 = new PointF(-Edge / 2f, Edge * sqrt3 / 2) + c;

			GraphicsPath = new GraphicsPath();
			GraphicsPath.AddLines(new[] { p1, p2, p3, p4, p5, p6, p1 });
		}
	}
}