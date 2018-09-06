using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

namespace TakeItEasy.View
{
	public class GameFieldView: HexagonStyle
	{
		private readonly Dictionary<int, HexagonView> hexagons;
		private SizeF size;

		public SizeF Size {
			get { return size; }
			set { size = value; CalculateHexagons(); }
		}

		public GameFieldView(SizeF size, HexagonStyle style)
		{
			hexagons = new Dictionary<int, HexagonView>();
			this.size = size;
			CalculateHexagons();

			Color = style.Color;
			BorderColor = style.BorderColor;
			BorderThickness = style.BorderThickness;
		}

		public int? GetPosition(Point point)
		{
			foreach (var h in hexagons)
			{
				using (var graphicsPath = new GraphicsPath())
				{
					graphicsPath.AddLines(h.Value.Hexagon.Vertices);
					if (graphicsPath.IsVisible(point))
						return h.Key;
				}
			}

			return null;
		}

		public IEnumerable<HexagonView> GetHexagons()
		{
			return hexagons.Select(x => x.Value);
		}

		public HexagonView GetHexagon(int index)
		{
			return hexagons[index];
		}

		private void CalculateHexagons()
		{
			var center = new PointF(size.Width / 2f, size.Height / 2f);
			var c = new SizeF(center);
			var a = Math.Min(size.Width, size.Height) / 9;

			var sqrt3 = (float) Math.Sqrt(3);

			hexagons.Clear();

			hexagons.Add(0, new HexagonView(a, new PointF(3 * a, sqrt3 * a) + c));
			hexagons.Add(1, new HexagonView(a, new PointF(3 * a, 0) + c));
			hexagons.Add(2, new HexagonView(a, new PointF(3 * a, -sqrt3 * a) + c));

			hexagons.Add(3, new HexagonView(a, new PointF(1.5f * a, 1.5f * sqrt3 * a) + c));
			hexagons.Add(4, new HexagonView(a, new PointF(1.5f * a, 0.5f * sqrt3 * a) + c));
			hexagons.Add(5, new HexagonView(a, new PointF(1.5f * a, -0.5f * sqrt3 * a) + c));
			hexagons.Add(6, new HexagonView(a, new PointF(1.5f * a, -1.5f * sqrt3 * a) + c));

			hexagons.Add(7, new HexagonView(a, new PointF(0, 2 * sqrt3 * a) + c));
			hexagons.Add(8, new HexagonView(a, new PointF(0, sqrt3 * a) + c));
			hexagons.Add(9, new HexagonView(a, new PointF(0, 0) + c));
			hexagons.Add(10, new HexagonView(a, new PointF(0, -sqrt3 * a) + c));
			hexagons.Add(11, new HexagonView(a, new PointF(0, -2 * sqrt3 * a) + c));

			hexagons.Add(12, new HexagonView(a, new PointF(-1.5f * a, 1.5f * sqrt3 * a) + c));
			hexagons.Add(13, new HexagonView(a, new PointF(-1.5f * a, 0.5f * sqrt3 * a) + c));
			hexagons.Add(14, new HexagonView(a, new PointF(-1.5f * a, -0.5f * sqrt3 * a) + c));
			hexagons.Add(15, new HexagonView(a, new PointF(-1.5f * a, -1.5f * sqrt3 * a) + c));

			hexagons.Add(16, new HexagonView(a, new PointF(-3 * a, sqrt3 * a) + c));
			hexagons.Add(17, new HexagonView(a, new PointF(-3 * a, 0) + c));
			hexagons.Add(18, new HexagonView(a, new PointF(-3 * a, -sqrt3 * a) + c));

			for (var i = 0; i < hexagons.Count; i++)
			{
				hexagons[i].Color = Color;
				hexagons[i].BorderColor = BorderColor;
				hexagons[i].BorderThickness = BorderThickness;
			}
		}
	}
}
