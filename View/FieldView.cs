using System;
using System.Collections.Generic;
using System.Drawing;
using TakeItEasy.Model;

namespace TakeItEasy.View
{
	public class FieldView
	{
		public Color FieldColor { get; set; }

		public IEnumerable<HexagonView> GetFieldHexagons()
		{
			return hexagons;
		}

		private readonly HexagonView[] hexagons;

		private const int IndexMax = 19;
		private static readonly float sqrt3 = (float)Math.Sqrt(3);

		public FieldView(SizeF fieldSize)
		{
			FieldColor = Color.DeepPink;

			hexagons = new HexagonView[IndexMax];

			InitializeFieldHexagons(fieldSize);
		}

		//public HexagonView GetFieldHexagon(int index)
		//{
		//	if (index > 0 && index < IndexMax)
		//		return hexagons[index];

		//	throw new ApplicationException($"There are only 19 hexagons on field. Index {index} is wrong");
		//}

		//public TileHexagonView GetTileHexagon(int index)
		//{
		//	if (tiles.ContainsKey(index))
		//		return tiles[index];

		//	throw new ApplicationException($"There is no tile on cell with index {index}");
		//}

		public void AddTileHexagon(int index, Tile tile)
		{
			if (index < 0 && index >= IndexMax)
				throw new ApplicationException($"There are only 19 cells on field. Index {index} is wrong");

				var hexagonView = hexagons[index];
			var tileHexagon = new TileHexagonView(hexagonView, tile);

			tileHexagon.HexagonView.Color = GameTileColor;
			tileHexagon.HexagonView.BorderColor = Color.Black;
			tileHexagon.HexagonView.BorderThickness = 0.01f;

			tiles.Add(index, tileHexagon);
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

			for (var i = 0; i < IndexMax; i++)
			{
				hexagons[i].Color = FieldColor;
				hexagons[i].BorderThickness = 0.05f;
			}
		}
	}
}
