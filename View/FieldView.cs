using System;
using System.Collections.Generic;
using System.Drawing;

namespace TakeItEasy.View
{
	public class FieldView
	{
		public Color Color { get; set; }
		public Color BorderColor { get; set; }
		public float BorderThickness { get; set; }
		public SizeF Size { get; set; }

		private readonly HexagonView[] hexagons;
		private const int MaxIndex = 19;
		private static readonly float sqrt3 = (float)Math.Sqrt(3);

		public FieldView(SizeF fieldSize, Color color, Color borderColor, float borderThickness)
		{
			Size = fieldSize;
			Color = color;
			BorderColor = borderColor;
			BorderThickness = borderThickness;

			hexagons = new HexagonView[MaxIndex];
			InitializeFieldHexagons(fieldSize);
		}

		public int? GetPosition(Point point)
		{
			var index = 0;
			foreach (var hexagon in hexagons)
			{
				if (hexagon.GraphicsPath.IsVisible(point))
					return index;
				index++;
			}
			return null;
		}

		public IEnumerable<HexagonView> GetFieldHexagons()
		{
			return hexagons;
		}

		public void Update(SizeF fieldSize)
		{
			InitializeFieldHexagons(fieldSize);
		}

		private void InitializeFieldHexagons(SizeF fieldSize)
		{
			var center = new PointF(fieldSize.Width / 2f, fieldSize.Height / 2f);
			var c = new SizeF(center);
			var a = Math.Min(fieldSize.Width, fieldSize.Height) / 9;

			hexagons[0] = new HexagonView(a, new PointF(3 * a, sqrt3 * a) + c);
			hexagons[1] = new HexagonView(a, new PointF(3 * a, 0) + c);
			hexagons[2] = new HexagonView(a, new PointF(3 * a, -sqrt3 * a) + c);

			hexagons[3] = new HexagonView(a, new PointF(1.5f * a, 1.5f * sqrt3 * a) + c);
			hexagons[4] = new HexagonView(a, new PointF(1.5f * a, 0.5f * sqrt3 * a) + c);
			hexagons[5] = new HexagonView(a, new PointF(1.5f * a, -0.5f * sqrt3 * a) + c);
			hexagons[6] = new HexagonView(a, new PointF(1.5f * a, -1.5f * sqrt3 * a) + c);

			hexagons[7] = new HexagonView(a, new PointF(0, 2 * sqrt3 * a) + c);
			hexagons[8] = new HexagonView(a, new PointF(0, sqrt3 * a) + c);
			hexagons[9] = new HexagonView(a, new PointF(0, 0) + c);
			hexagons[10] = new HexagonView(a, new PointF(0, -sqrt3 * a) + c);
			hexagons[11] = new HexagonView(a, new PointF(0, -2 * sqrt3 * a) + c);

			hexagons[12] = new HexagonView(a, new PointF(-1.5f * a, 1.5f * sqrt3 * a) + c);
			hexagons[13] = new HexagonView(a, new PointF(-1.5f * a, 0.5f * sqrt3 * a) + c);
			hexagons[14] = new HexagonView(a, new PointF(-1.5f * a, -0.5f * sqrt3 * a) + c);
			hexagons[15] = new HexagonView(a, new PointF(-1.5f * a, -1.5f * sqrt3 * a) + c);

			hexagons[16] = new HexagonView(a, new PointF(-3 * a, sqrt3 * a) + c);
			hexagons[17] = new HexagonView(a, new PointF(-3 * a, 0) + c);
			hexagons[18] = new HexagonView(a, new PointF(-3 * a, -sqrt3 * a) + c);

			for (var i = 0; i < MaxIndex; i++)
			{
				hexagons[i].Color = Color;
				hexagons[i].BorderColor = BorderColor;
				hexagons[i].BorderThickness = BorderThickness;
			}
		}
	}
}
