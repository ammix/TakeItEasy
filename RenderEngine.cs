using System.Drawing;
using System.Drawing.Drawing2D;

using TakeItEasy.View;

namespace TakeItEasy
{
	public static class RenderEngine
	{
		public static void DrawGameView(Graphics g, GameView gameView)
		{
			g.Clear(Color.Black);

			foreach (var hexagons in gameView.GetFieldHexagons())
				DrawHexagon(g, hexagons);

			foreach (var tile in gameView.GetTileHexagons())
				DrawTileHexagon(g, tile);

			if (gameView.FreeTile != null)
				DrawTileHexagon(g, gameView.FreeTile);
		}

		public static void DrawHexagon(Graphics g, HexagonView hx)
		{
			using (var graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddLines(hx.Vertices);
				g.FillPath(new SolidBrush(hx.HexagonStyle.Color), graphicsPath);
				g.DrawPath(new Pen(hx.HexagonStyle.BorderColor, hx.HexagonStyle.BorderThickness * hx.Hexagon.Edge) {EndCap = LineCap.Round}, graphicsPath);
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
				DrawNumber(g, bar.Number, bar.NumberPosition, bar.NumberStyle);
			}
		}

		private static void DrawBar(Graphics g, GraphicsPath bar, Color color)
		{
			g.FillPath(new SolidBrush(color), bar);
			g.DrawPath(new Pen(Color.Black), bar);
		}

		private static void DrawNumber(Graphics g, int number, PointF numberPosition, NumberStyle numberStyle)
		{
			var font = new Font("Arial", numberStyle.FontSize, FontStyle.Regular);

			var drawFormat = new StringFormat
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center
			};

			using (font)
			using (drawFormat)
				g.DrawString(number.ToString(), font, new SolidBrush(numberStyle.Color), numberPosition, drawFormat);
		}
	}
}
