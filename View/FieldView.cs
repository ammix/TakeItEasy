using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using TakeItEasy.Rendering;

namespace TakeItEasy.View
{
	public class FieldView
	{
		public Color Color { get; set; }
		public Color BorderColor { get; set; }
		public float BorderThickness { get; set; }
		public SizeF Size { get; set; }

		private readonly Dictionary<int, HexagonGraphics> hexagons;
		//private readonly Dictionary<int, Tuple<HexagonView, GraphicsPath>> hexagons;
		//private HexagonGraphics[] hexagons;

		public FieldView(SizeF fieldSize, Color color, Color borderColor, float borderThickness)
		{
			Size = fieldSize;
			Color = color;
			BorderColor = borderColor;
			BorderThickness = borderThickness;

			hexagons = new Dictionary<int, HexagonGraphics>();
			//hexagons = new Dictionary<int, Tuple<HexagonView, GraphicsPath>>();
			//hexagons = hexagons = new HexagonGraphics[MaxIndex];
			InitializeFieldHexagons(fieldSize);
		}

		public int? GetPosition(Point point)
		{
			foreach (var hexagon in hexagons)
			{
				if (hexagon.Value.Graphics.IsVisible(point))
					return hexagon.Key;
			}

			return null;
		}

		public IEnumerable<HexagonGraphics> GetHexagons()
		{
			return hexagons.Select(x => x.Value);
		}

		public HexagonGraphics GetHexagon(int index)
		{
			return hexagons[index];
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

			float sqrt3 = (float) Math.Sqrt(3);

			hexagons.Clear();

			hexagons.Add(0, new HexagonGraphics(a, new PointF(3 * a, sqrt3 * a) + c));

			hexagons.Add(1, new HexagonGraphics(a, new PointF(3 * a, 0) + c));
			hexagons.Add(2, new HexagonGraphics(a, new PointF(3 * a, -sqrt3 * a) + c));

			hexagons.Add(3, new HexagonGraphics(a, new PointF(1.5f * a, 1.5f * sqrt3 * a) + c));
			hexagons.Add(4, new HexagonGraphics(a, new PointF(1.5f * a, 0.5f * sqrt3 * a) + c));
			hexagons.Add(5, new HexagonGraphics(a, new PointF(1.5f * a, -0.5f * sqrt3 * a) + c));
			hexagons.Add(6, new HexagonGraphics(a, new PointF(1.5f * a, -1.5f * sqrt3 * a) + c));

			hexagons.Add(7, new HexagonGraphics(a, new PointF(0, 2 * sqrt3 * a) + c));
			hexagons.Add(8, new HexagonGraphics(a, new PointF(0, sqrt3 * a) + c));
			hexagons.Add(9, new HexagonGraphics(a, new PointF(0, 0) + c));
			hexagons.Add(10, new HexagonGraphics(a, new PointF(0, -sqrt3 * a) + c));
			hexagons.Add(11, new HexagonGraphics(a, new PointF(0, -2 * sqrt3 * a) + c));

			hexagons.Add(12, new HexagonGraphics(a, new PointF(-1.5f * a, 1.5f * sqrt3 * a) + c));
			hexagons.Add(13, new HexagonGraphics(a, new PointF(-1.5f * a, 0.5f * sqrt3 * a) + c));
			hexagons.Add(14, new HexagonGraphics(a, new PointF(-1.5f * a, -0.5f * sqrt3 * a) + c));
			hexagons.Add(15, new HexagonGraphics(a, new PointF(-1.5f * a, -1.5f * sqrt3 * a) + c));

			hexagons.Add(16, new HexagonGraphics(a, new PointF(-3 * a, sqrt3 * a) + c));
			hexagons.Add(17, new HexagonGraphics(a, new PointF(-3 * a, 0) + c));
			hexagons.Add(18, new HexagonGraphics(a, new PointF(-3 * a, -sqrt3 * a) + c));

			for (var i = 0; i < hexagons.Count; i++)
			{
				hexagons[i].Color = Color;
				hexagons[i].BorderColor = BorderColor;
				hexagons[i].BorderThickness = BorderThickness;
			}
		}
	}
}
