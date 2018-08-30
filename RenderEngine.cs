using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy
{
	public static class RenderEngine
	{
		private static readonly float K = (float) Math.Sqrt(3) / 2;

		public static void DrawHexagon(Graphics g, HexagonView hx)
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

		public static void DrawTileHexagon(Graphics g, TileHexagonView hx)
		{
			DrawHexagon(g, hx.HexagonView);

			var a = hx.HexagonView.Edge;
			var b = a * 15 / 62;
			var center = hx.HexagonView.Center;
            var sqrt3 = (float)Math.Sqrt(3);
			var c = new SizeF(center);
			var fontSize = b;

			var p7 = new PointF(b / 2f, a * sqrt3 / 2);
			var p8 = new PointF(a * 3 / 4 - b / 4, a * sqrt3 / 4 + b * sqrt3 / 4);
			var p9 = new PointF(a * 3 / 4 + b / 4, a * sqrt3 / 4 - b * sqrt3 / 4);
			var p10 = new PointF(a * 3 / 4 + b / 4, -a * sqrt3 / 4 + b * sqrt3 / 4);
			var p11 = new PointF(a * 3 / 4 - b / 4, -a * sqrt3 / 4 - b * sqrt3 / 4);
			var p12 = new PointF(b / 2f, -a * sqrt3 / 2);
			var p1 = new PointF(-b / 2f, -a * sqrt3 / 2);
			var p2 = new PointF(-a * 3 / 4 + b / 4, -a * sqrt3 / 4 - b * sqrt3 / 4);
			var p3 = new PointF(-a * 3 / 4 - b / 4, -a * sqrt3 / 4 + b * sqrt3 / 4);
			var p4 = new PointF(-a * 3 / 4 - b / 4, a * sqrt3 / 4 - b * sqrt3 / 4);
			var p5 = new PointF(-a * 3 / 4 + b / 4, a * sqrt3 / 4 + b * sqrt3 / 4);
			var p6 = new PointF(-b / 2f, a * sqrt3 / 2);

			var barTop = new GraphicsPath();
			barTop.AddLines(new[] { p12 + c, p1 + c, p6 + c, p7 + c, p12 + c });

			var barLeft = new GraphicsPath();
			//barLeft.AddLines(new[] { p2 + c, p3 + c, p8 + c, p9 + c, p2 + c });
			barLeft.AddLines(new[] { p8 + c, p9 + c, p2 + c, p3 + c, p8 + c });

			var barRight = new GraphicsPath();
			barRight.AddLines(new[] { p4 + c, p5 + c, p10 + c, p11 + c, p4 + c });

			for (var i = 1; i <= 3; i++)
			{
				var number = GetNumber(i, hx.TileModel.Top, hx.TileModel.Right, hx.TileModel.Left);
				var bar = GetBar(number, barTop, barLeft, barRight);
				var color = GetBarColor(number);
				DrawBar(g, bar, color); // 7->orient+color
				DrawNumber(g, number, bar);
			}

			//g.DrawString(hx.TileModel.Left.ToString(), new Font("Arial", fontSize, FontStyle.Regular), new SolidBrush(Color.Black), center.X - p4.X + b / 5, center.Y - p4.Y - b / 2);
			//g.DrawString(hx.TileModel.Right.ToString(), new Font("Arial", fontSize, FontStyle.Regular), new SolidBrush(Color.Black), center.X - p9.X - b * 1.25f, center.Y - p9.Y - b / 2);
			//g.DrawString(hx.TileModel.Top.ToString(), new Font("Arial", fontSize, FontStyle.Regular), new SolidBrush(Color.Black), center.X - b / 1.75f, center.Y - a * sqrt3 / 2);

			/*
			//var drawRect = new RectangleF(center, new SizeF(0, 0));
			var drawFormat = new StringFormat();
			drawFormat.Alignment = StringAlignment.Center;
			drawFormat.LineAlignment = StringAlignment.Center;

			g.DrawString("0", new Font("Arial", b, FontStyle.Regular), new SolidBrush(Color.Black), center.X, center.Y - (a * sqrt3 / 2) + fontSize, drawFormat);
			*/
		}

		public static void DrawNumber(Graphics g, int number, GraphicsPath bar)
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

		public static void DrawBar(Graphics g, GraphicsPath bar, Color color)
		{
			g.FillPath(new SolidBrush(color), bar);
			g.DrawPath(new Pen(Color.Black), bar);
		}

		private static int GetNumber(int order, int n1, int n2, int n3)
		{
			var list = new List<int> {n1, n2, n3};
			list.Sort();
			return list[order - 1];
		}

		private static GraphicsPath GetBar(int number, GraphicsPath barTop, GraphicsPath barLeft, GraphicsPath barRight)
		{
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

		public static void DrawGameField(Graphics g, SizeF fieldSize, List<bool> model)
		{
			var c = new PointF(fieldSize.Width / 2f, fieldSize.Height / 2f);
			var a = Math.Min(fieldSize.Width, fieldSize.Height) / 9;
			var dy = (float) Math.Sqrt(3) * a;

			var hexagons = new List<HexagonView>
			{
				new HexagonView(a, new PointF(c.X + 3 * a, c.Y + dy)),
				new HexagonView(a, new PointF(c.X + 3 * a, c.Y)),
				new HexagonView(a, new PointF(c.X + 3 * a, c.Y - dy)),

				new HexagonView(a, new PointF(c.X + 1.5f * a, c.Y + 1.5f * dy)),
				new HexagonView(a, new PointF(c.X + 1.5f * a, c.Y + 0.5f * dy)),
				new HexagonView(a, new PointF(c.X + 1.5f * a, c.Y - 0.5f * dy)),
				new HexagonView(a, new PointF(c.X + 1.5f * a, c.Y - 1.5f * dy)),

				new HexagonView(a, new PointF(c.X, c.Y + 2 * dy)),
				new HexagonView(a, new PointF(c.X, c.Y + dy)),
				new HexagonView(a, new PointF(c.X, c.Y)),
				new HexagonView(a, new PointF(c.X, c.Y - dy)),
				new HexagonView(a, new PointF(c.X, c.Y - 2 * dy)),

				new HexagonView(a, new PointF(c.X - 1.5f * a, c.Y + 1.5f * dy)),
				new HexagonView(a, new PointF(c.X - 1.5f * a, c.Y + 0.5f * dy)),
				new HexagonView(a, new PointF(c.X - 1.5f * a, c.Y - 0.5f * dy)),
				new HexagonView(a, new PointF(c.X - 1.5f * a, c.Y - 1.5f * dy)),

				new HexagonView(a, new PointF(c.X - 3 * a, c.Y + dy)),
				new HexagonView(a, new PointF(c.X - 3 * a, c.Y)),
				new HexagonView(a, new PointF(c.X - 3 * a, c.Y - dy))
			};

			g.Clear(Color.Black);
			foreach (var hx in hexagons)
				DrawHexagon(g, hx);
		}
	}
}
