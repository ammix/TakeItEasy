using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy.Rendering
{
	public class BarGraphics: IDisposable
	{
		public int Number { get; }
		public Color Color { get; }
		public GraphicsPath Graphics { get; }

		public BarGraphics(Hexagon hexagon, int number)
		{
			Number = number;
			Color = GetBarColor(number);
			Graphics = GetBar(number, hexagon);
		}

		public void Dispose()
		{
			Graphics.Dispose();
		}

		private static GraphicsPath GetBar(int number, Hexagon hx)
		{
			var a = hx.Edge;
			var b = a * 15 / 62;
			var center = hx.Center;
			var c = new SizeF(center);

			var sqrt3 = (float)Math.Sqrt(3);
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
				case 1: return Color.DimGray;
				case 2: return Color.Silver;
				case 3: return Color.Pink;
				case 4: return Color.DeepSkyBlue;
				case 5: return Color.DarkGray; //Gray;
				case 6: return Color.DeepPink;
				case 7: return Color.LimeGreen; // LawnGreen;
				case 8: return Color.Orange;
				case 9: return Color.Yellow;
				default: return Color.White;
			}
		}
	}
}
