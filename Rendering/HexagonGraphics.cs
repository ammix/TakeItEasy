using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy.Rendering
{
	public class HexagonGraphics: IDisposable
	{
		private Hexagon hexagon;

		public Hexagon Hexagon
		{
			get { return hexagon; }
			set { hexagon = value; Initialize(hexagon); }
		}

		public Color Color { get; set; }
		public Color BorderColor { get; set; }
		public float BorderThickness { get; set; } // ratio border to edge

		public GraphicsPath Graphics { get; private set; }

		public HexagonGraphics(Hexagon hexagon)
		{
			Hexagon = hexagon;
		}

		public HexagonGraphics(float edge, PointF center) : this(new Hexagon {Edge = edge, Center = center})
		{ }

		public virtual void Dispose()
		{
			Graphics.Dispose();
		}

		private void Initialize(Hexagon hx)
		{
			var a = hx.Edge;
			var center = new SizeF(hx.Center);

			var sqrt3 = (float) Math.Sqrt(3);
			var p1 = new PointF(a / 2f, a * sqrt3 / 2) + center;
			var p2 = new PointF(a, 0) + center;
			var p3 = new PointF(a / 2f, -a * sqrt3 / 2) + center;
			var p4 = new PointF(-a / 2f, -a * sqrt3 / 2) + center;
			var p5 = new PointF(-a, 0) + center;
			var p6 = new PointF(-a / 2f, a * sqrt3 / 2) + center;

			Graphics = new GraphicsPath();
			Graphics.AddLines(new[] { p1, p2, p3, p4, p5, p6, p1 });
		}
	}
}
