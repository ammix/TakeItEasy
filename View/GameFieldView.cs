using System;
using System.Drawing;

namespace TakeItEasy.Model
{
	public class GameFieldView
	{
		private static readonly float sqrt3 = (float)Math.Sqrt(3);

		public Color FieldColor { get; set; }
		public HexagonView[] Hexagons { get; }

		public GameFieldView(SizeF fieldSize)
		{
			FieldColor = Color.DeepPink;
			Hexagons = new HexagonView[19];

			var center = new PointF(fieldSize.Width / 2f, fieldSize.Height / 2f);
			var c = new SizeF(center);
			var a = Math.Min(fieldSize.Width, fieldSize.Height) / 9;

			Hexagons[0] = new HexagonView(a, new PointF(3 * a, sqrt3 * a) + c);
			Hexagons[1] = new HexagonView(a, new PointF(3 * a, 0) + c);
			Hexagons[2] = new HexagonView(a, new PointF(3 * a, -sqrt3 * a) + c);

			Hexagons[3] = new HexagonView(a, new PointF(1.5f * a, 1.5f * sqrt3 * a) + c);
			Hexagons[4] = new HexagonView(a, new PointF(1.5f * a, 0.5f * sqrt3 * a) + c);
			Hexagons[5] = new HexagonView(a, new PointF(1.5f * a, -0.5f * sqrt3 * a) + c);
			Hexagons[6] = new HexagonView(a, new PointF(1.5f * a, -1.5f * sqrt3 * a) + c);

			Hexagons[7] = new HexagonView(a, new PointF(0, 2 * sqrt3 * a) + c);
			Hexagons[8] = new HexagonView(a, new PointF(0, sqrt3 * a) + c);
			Hexagons[9] = new HexagonView(a, new PointF(0, 0) + c);
			Hexagons[10] = new HexagonView(a, new PointF(0, -sqrt3 * a) + c);
			Hexagons[11] = new HexagonView(a, new PointF(0, -2 * sqrt3 * a) + c);

			Hexagons[12] = new HexagonView(a, new PointF(-1.5f * a, 1.5f * sqrt3 * a) + c);
			Hexagons[13] = new HexagonView(a, new PointF(-1.5f * a, 0.5f * sqrt3 * a) + c);
			Hexagons[14] = new HexagonView(a, new PointF(-1.5f * a, -0.5f * sqrt3 * a) + c);
			Hexagons[15] = new HexagonView(a, new PointF(-1.5f * a, -1.5f * sqrt3 * a) + c);

			Hexagons[16] = new HexagonView(a, new PointF(-3 * a, sqrt3 * a) + c);
			Hexagons[17] = new HexagonView(a, new PointF(-3 * a, 0) + c);
			Hexagons[18] = new HexagonView(a, new PointF(-3 * a, -sqrt3 * a) + c);
		}
	}
}
