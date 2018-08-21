using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy
{
	class Hexagon
	{
		public float Edge { get; set; }
		public PointF Center { get; set; }
		public Color BorderColor { get; set; }
		public Color Color { get; set; }

		private GraphicsPath path;

		protected virtual float LineSizeRation { get; set; } = 0.05f;

		public Hexagon(PointF center, float edge)
		{
			Center = center;
			Edge = edge;

			Initialize();
		}

		private void Initialize()
		{
			var k = (float)(Math.Sqrt(3) / 2);

			var p1 = new PointF(Center.X + Edge / 2f, Center.Y + k * Edge);
			var p2 = new PointF(Center.X + Edge, Center.Y);
			var p3 = new PointF(Center.X + Edge / 2f, Center.Y - k * Edge);
			var p4 = new PointF(Center.X - Edge / 2f, Center.Y - k * Edge);
			var p5 = new PointF(Center.X - Edge, Center.Y);
			var p6 = new PointF(Center.X - Edge / 2f, Center.Y + k * Edge);

			path = new GraphicsPath();
			path.AddLines(new[] {p1, p2, p3, p4, p5, p6, p1});
		}

		public virtual void Draw(Graphics g)
		{
			//Initialize();

			g.FillPath(new SolidBrush(Color), path);
			//g.FillPolygon(new SolidBrush(Color.DeepPink), points);

			g.DrawPath(new Pen(BorderColor, LineSizeRation * Edge) { EndCap = LineCap.Round }, path);
			//g.DrawLines(pen, points);
		}

		public bool Contains(PointF point)
		{
			return path.IsVisible(point);
		}

		public void Set(PointF center, float edge)
		{
			Center = center;
			Edge = edge;

			Initialize();
		}
	}
}
