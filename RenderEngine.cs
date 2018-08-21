using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy
{
	public static class RenderEngine
	{
		private static readonly float K = (float) Math.Sqrt(3) / 2;

		public static void DrawHexagon(Graphics g, FieldHexagonView hx)
		{
			var p1 = new PointF(hx.Center.X + hx.Edge / 2f, hx.Center.Y + K * hx.Edge);
			var p2 = new PointF(hx.Center.X + hx.Edge, hx.Center.Y);
			var p3 = new PointF(hx.Center.X + hx.Edge / 2f, hx.Center.Y - K * hx.Edge);
			var p4 = new PointF(hx.Center.X - hx.Edge / 2f, hx.Center.Y - K * hx.Edge);
			var p5 = new PointF(hx.Center.X - hx.Edge, hx.Center.Y);
			var p6 = new PointF(hx.Center.X - hx.Edge / 2f, hx.Center.Y + K * hx.Edge);

			var path = new GraphicsPath();
			path.AddLines(new[] { p1, p2, p3, p4, p5, p6, p1 });

			g.FillPath(new SolidBrush(hx.Color), path);
			g.DrawPath(new Pen(hx.BorderColor, hx.BorderThickness * hx.Edge) { EndCap = LineCap.Round }, path);
		}

		public static void DrawGameField(Graphics g, SizeF fieldSize, List<bool> model)
		{
			var c = new PointF(fieldSize.Width / 2f, fieldSize.Height / 2f);
			var a = Math.Min(fieldSize.Width, fieldSize.Height) / 9;
			var dy = (float) Math.Sqrt(3) * a;

			var hexagons = new List<FieldHexagonView>
			{
				new FieldHexagonView(a, new PointF(c.X + 3 * a, c.Y + dy)),
				new FieldHexagonView(a, new PointF(c.X + 3 * a, c.Y)),
				new FieldHexagonView(a, new PointF(c.X + 3 * a, c.Y - dy)),

				new FieldHexagonView(a, new PointF(c.X + 1.5f * a, c.Y + 1.5f * dy)),
				new FieldHexagonView(a, new PointF(c.X + 1.5f * a, c.Y + 0.5f * dy)),
				new FieldHexagonView(a, new PointF(c.X + 1.5f * a, c.Y - 0.5f * dy)),
				new FieldHexagonView(a, new PointF(c.X + 1.5f * a, c.Y - 1.5f * dy)),

				new FieldHexagonView(a, new PointF(c.X, c.Y + 2 * dy)),
				new FieldHexagonView(a, new PointF(c.X, c.Y + dy)),
				new FieldHexagonView(a, new PointF(c.X, c.Y)),
				new FieldHexagonView(a, new PointF(c.X, c.Y - dy)),
				new FieldHexagonView(a, new PointF(c.X, c.Y - 2 * dy)),

				new FieldHexagonView(a, new PointF(c.X - 1.5f * a, c.Y + 1.5f * dy)),
				new FieldHexagonView(a, new PointF(c.X - 1.5f * a, c.Y + 0.5f * dy)),
				new FieldHexagonView(a, new PointF(c.X - 1.5f * a, c.Y - 0.5f * dy)),
				new FieldHexagonView(a, new PointF(c.X - 1.5f * a, c.Y - 1.5f * dy)),

				new FieldHexagonView(a, new PointF(c.X - 3 * a, c.Y + dy)),
				new FieldHexagonView(a, new PointF(c.X - 3 * a, c.Y)),
				new FieldHexagonView(a, new PointF(c.X - 3 * a, c.Y - dy))
			};

			g.Clear(Color.Black);
			foreach (var hx in hexagons)
				DrawHexagon(g, hx);
		}
	}
}
