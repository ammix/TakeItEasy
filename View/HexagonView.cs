using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy.View
{
	public struct HexagonView
	{
		private static readonly float sqrt3 = (float) Math.Sqrt(3);
		private float edge;
		private PointF center;

		public float Edge
		{
			get { return edge; }
			set { edge = value; Update(); }
		}

		public PointF Center
		{
			get { return center; }
			set { center = value; Update(); }
		}

		public Color BorderColor { get; set; }
		public Color Color { get; set; }
		public float BorderThickness { get; set; } // ratio border to edge
		public GraphicsPath GraphicsPath { get; }



		public HexagonView(float edge, PointF center)
		{
			this.edge = edge;
			this.center = center;
			BorderColor = Color.Black;
			Color = Color.White;
			BorderThickness = 0.01f;

			GraphicsPath = new GraphicsPath();
			Update();
		}

		private void Update()
		{
			GraphicsPath.Reset();
			var c = new SizeF(center);

			var p1 = new PointF(Edge / 2f, Edge * sqrt3 / 2) + c;
			var p2 = new PointF(Edge, 0) + c;
			var p3 = new PointF(Edge / 2f, -Edge * sqrt3 / 2) + c;
			var p4 = new PointF(-Edge / 2f, -Edge * sqrt3 / 2) + c;
			var p5 = new PointF(-Edge, 0) + c;
			var p6 = new PointF(-Edge / 2f, Edge * sqrt3 / 2) + c;

			GraphicsPath.AddLines(new[] {p1, p2, p3, p4, p5, p6, p1});
		}
	}
}