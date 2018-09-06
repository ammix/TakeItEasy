using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using TakeItEasy.Model;
using TakeItEasy.Rendering;
using TakeItEasy.View;

namespace TakeItEasy
{
	public static class RenderEngine
	{
		private static readonly float sqrt3 = (float) Math.Sqrt(3);

		public static void DrawGameView(Graphics g, GameView gameView)
		{
			foreach (var tile in gameView.GetTileHexagons())
				DrawTileHexagon(g, tile);
		}

		public static void DrawFieldView(Graphics g, FieldView fieldView)
		{
			g.Clear(Color.Black);

			foreach (var hexagons in fieldView.GetHexagons())
				DrawHexagon(g, hexagons);
		}

		public static void DrawHexagon(Graphics g, HexagonGraphics hx)
		{
			g.FillPath(new SolidBrush(hx.Color), hx.Graphics);
			g.DrawPath(new Pen(hx.BorderColor, hx.BorderThickness * hx.Hexagon.Edge) { EndCap = LineCap.Round }, hx.Graphics);
		}

		public static void DrawTileHexagon(Graphics g, TileGraphics hx)
		{
			DrawHexagon(g, hx);

			foreach (var bar in hx.Bars)
			{
				DrawBar(g, bar.Graphics, bar.Color);
				DrawNumber(g, bar.Number, bar.Graphics);
			}

			//for (var i = 0; i < 3; i++)
			//{
			//	//var number = GetNumber(i, hx.Tile);
			//	//var bar = GetBar(number, hx.HexagonView);
			//	//var color = GetBarColor(number);

			//	//DrawBar(g, bar, color);
			//	var x = hx.Bars[i];
			//	DrawNumber(g, number, bar);
			//}
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
