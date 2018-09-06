using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy.View
{
	public static class RenderEngine
	{
		public static void DrawGameView(Graphics g, GameTilesView gameTilesView)
		{
			foreach (var tile in gameTilesView.GetTileHexagons())
				DrawTileHexagon(g, tile);
		}

		public static void DrawFieldView(Graphics g, GameFieldView gameFieldView)
		{
			g.Clear(Color.Black);

			foreach (var hexagons in gameFieldView.GetHexagons())
				DrawHexagon(g, hexagons);
		}

		public static void DrawHexagon(Graphics g, HexagonView hx)
		{
			using (var graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddLines(hx.Hexagon.Vertices);
				g.FillPath(new SolidBrush(hx.Color), graphicsPath);
				g.DrawPath(new Pen(hx.BorderColor, hx.BorderThickness * hx.Hexagon.Edge) {EndCap = LineCap.Round}, graphicsPath);
			}
		}

		public static void DrawTileHexagon(Graphics g, TileView hx)
		{
			DrawHexagon(g, hx);

			foreach (var bar in hx.BarsView)
			using (var graphicPath = new GraphicsPath())
			{
				graphicPath.AddLines(bar.Vertices);
				DrawBar(g, graphicPath, bar.Color);
				DrawNumber(g, bar.Number, graphicPath);
			}
		}

		private static void DrawBar(Graphics g, GraphicsPath bar, Color color)
		{
			g.FillPath(new SolidBrush(color), bar);
			g.DrawPath(new Pen(Color.Black), bar);
		}

		private static void DrawNumber(Graphics g, int number, GraphicsPath bar)
		{
			var p1 = bar.PathPoints[0];
			var p2 = bar.PathPoints[1];
			var p3 = bar.PathPoints[2];

			var c = new PointF((p1.X + p3.X) / 2, (p1.Y + p3.Y) / 2);
			var p = new PointF((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);

			var fontSize = (float)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
			var r = (float) Math.Sqrt(Math.Pow(p.X - c.X, 2) + Math.Pow(p.Y - c.Y, 2));

			var d = 0.18f * r; //8;
			var dy = 0.02f * r;
			var cosA = (p.X - c.X) / r;
			var sinA = (p.Y - c.Y) / r;
			var pNumber = new PointF(p.X - d * cosA, p.Y - d * sinA + dy);

			var font = new Font("Arial", fontSize, FontStyle.Regular);

			var drawFormat = new StringFormat
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};

			g.DrawString(number.ToString(), font, new SolidBrush(Color.Black), pNumber, drawFormat);
		}
	}
}
