using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy.View
{
	public class HexagonView
	{
		private Hexagon hexagon;

		public Hexagon Hexagon
		{
			get { return hexagon; }
			protected set { hexagon = value; InitializeVertices(); }
		}
		public HexagonStyle HexagonStyle { get; set; }
		public PointF[] Vertices { get; private set; }

		//TODO: remove this
		protected HexagonView(float edge, PointF center)
		{
			Hexagon = new Hexagon(edge, center);
			HexagonStyle = new HexagonStyle(Color.White, Color.Black, 0.01f);

			InitializeVertices();
		}

		private void InitializeVertices()
		{
			var a = Hexagon.Edge;
			var c = new SizeF(Hexagon.Center);

			//TODO: move to HexagonView
			var sqrt3 = (float) Math.Sqrt(3);
			var p1 = new PointF(a / 2f, a * sqrt3 / 2) + c;
			var p2 = new PointF(a, 0) + c;
			var p3 = new PointF(a / 2f, -a * sqrt3 / 2) + c;
			var p4 = new PointF(-a / 2f, -a * sqrt3 / 2) + c;
			var p5 = new PointF(-a, 0) + c;
			var p6 = new PointF(-a / 2f, a * sqrt3 / 2) + c;

			Vertices = new[] {p1, p2, p3, p4, p5, p6, p1};
		}

		public HexagonView(float edge, PointF center, HexagonStyle style)
			: this(edge, center)
		{
			HexagonStyle = style;
		}

		public bool Contains(Point point)
		{
			using (var graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddLines(Vertices);
				if (graphicsPath.IsVisible(point))
					return true;
			}
			return false;
		}
	}
}