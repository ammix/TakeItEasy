﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using TakeItEasy.Model;
using TakeItEasy.View;

namespace TakeItEasy
{
	public static class RenderEngine
	{
		private static readonly float sqrt3 = (float) Math.Sqrt(3);

		public static void DrawGame(Graphics g, SizeF fieldSize, Game game)
		{
			
		}

		public static void DrawGameField(Graphics g, FieldView field, GameView game)
		{
			g.Clear(Color.Black);

			foreach (var hexagons in field.GetFieldHexagons())
				DrawHexagon(g, hexagons);

			foreach (var tile in game.GetTileHexagons())
				DrawTileHexagon(g, tile);

			//foreach (var hx in hexagons)
			//	DrawHexagon(g, hx);
			//for (var i=0; i<19; i++)
			//	if (game.Tiles[i] == null)
			//		DrawHexagon(g, field.Hexagons[i]);
			//	else
			//	{
			//		var hexagonView = field.Hexagons[i];
			//		hexagonView.Color = Color.DeepSkyBlue;
			//		hexagonView.BorderThickness = 0.01f;
			//		hexagonView.BorderColor = Color.Black;

			//		var tileHexagonView = new TileHexagonView(hexagonView, game.Tiles[i].Value);
			//		DrawTileHexagon(g, tileHexagonView);
			//	}
		}

		public static void DrawHexagon(Graphics g, HexagonView hx)
		{
			g.FillPath(new SolidBrush(hx.Color), hx.GraphicsPath);
			g.DrawPath(new Pen(hx.BorderColor, hx.BorderThickness * hx.Edge) { EndCap = LineCap.Round }, hx.GraphicsPath);
		}

		public static void DrawTileHexagon(Graphics g, TileHexagonView hx)
		{
			DrawHexagon(g, hx.HexagonView);

			for (var i = 0; i < 3; i++)
			{
				var number = GetNumber(i, hx.Tile);
				var bar = GetBar(number, hx.HexagonView);
				var color = GetBarColor(number);

				DrawBar(g, bar, color);
				DrawNumber(g, number, bar);
			}
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

		private static void DrawBar(Graphics g, GraphicsPath bar, Color color)
		{
			g.FillPath(new SolidBrush(color), bar);
			g.DrawPath(new Pen(Color.Black), bar);
		}

		private static int GetNumber(int order, Tile model)
		{
			var list = new List<int> {model.LeftNumber, model.TopNumber, model.RightNumber};
			list.Sort();
			return list[order];
		}

		private static GraphicsPath GetBar(int number, HexagonView hx)
		{
			var a = hx.Edge;
			var b = a * 15 / 62;
			var center = hx.Center;
			var c = new SizeF(center);

			var p7 = new PointF(b / 2f, a * sqrt3 / 2) + c;
			var p8 = new PointF(a * 3 / 4 - b / 4, a * sqrt3 / 4 + b * sqrt3 / 4) + c;
			var p9 = new PointF(a * 3 / 4 + b / 4, a * sqrt3 / 4 - b * sqrt3 / 4) + c;
			var p10 = new PointF(a * 3 / 4 + b / 4, -a * sqrt3 / 4 + b * sqrt3 / 4) + c;
			var p11 = new PointF(a * 3 / 4 - b / 4, -a * sqrt3 / 4 - b * sqrt3 / 4) + c;
			var p12 = new PointF(b / 2f, -a * sqrt3 / 2) + c;
			var p1 = new PointF(-b / 2f, -a * sqrt3 / 2) + c;
			var p2 = new PointF(-a * 3 / 4 + b / 4, -a * sqrt3 / 4 - b * sqrt3 / 4) + c;
			var p3 = new PointF(-a * 3 / 4 - b / 4, -a * sqrt3 / 4 + b * sqrt3 / 4) + c;
			var p4 = new PointF(-a * 3 / 4 - b / 4, a * sqrt3 / 4 - b * sqrt3 / 4) + c;
			var p5 = new PointF(-a * 3 / 4 + b / 4, a * sqrt3 / 4 + b * sqrt3 / 4) + c;
			var p6 = new PointF(-b / 2f, a * sqrt3 / 2) + c;

			var barTop = new GraphicsPath();
			barTop.AddLines(new[] { p12, p1, p6, p7, p12 });

			var barLeft = new GraphicsPath();
			barLeft.AddLines(new[] { p8, p9, p2, p3, p8 });

			var barRight = new GraphicsPath();
			barRight.AddLines(new[] { p4, p5, p10, p11, p4 });

			switch (number)
			{
				case 1:
				case 5:
				case 9: return barTop;
				case 2:
				case 6:
				case 7: return barRight; 
				case 3:
				case 4:
				case 8: return barLeft;
			}
			throw new ApplicationException($"number {number} is not allowed");
		}

		private static Color GetBarColor(int number)
		{
			switch (number)
			{
				case 1: return Color.Black;
				case 2: return Color.Silver;
				case 3: return Color.Pink;
				case 4: return Color.DeepSkyBlue;
				case 5: return Color.Gray;
				case 6: return Color.Red;
				case 7: return Color.LimeGreen; // LawnGreen;
				case 8: return Color.Orange;
				case 9: return Color.Yellow;
				default: return Color.White;
			}
		}
	}
}
