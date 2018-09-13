using System.Collections.Generic;
using System.Drawing;

using TakeItEasy.Model;

namespace TakeItEasy.View
{
	public class TileView: HexagonView
	{
		public TileBarView[] BarsView { get; }
		public Tile Tile { get; }

		public TileView(Tile tile, float edge, PointF center) : base(edge, center)
		{
			Tile = tile;
			BarsView = new TileBarView[3];

			for (var i = 0; i < 3; i++)
			{
				var number = GetNumber(i, tile);
				BarsView[i] = new TileBarView(Hexagon, number);
			}
		}

		public TileView(Tile tile, float edge, PointF center, HexagonStyle style) : this(tile, edge, center)
		{
			HexagonStyle = style;
		}

		//TODO: combine? do immutable?
		public void Update(float edge)
		{
			Hexagon = new Hexagon(edge, Hexagon.Center);

			for (var i = 0; i < 3; i++)
				BarsView[i] = new TileBarView(Hexagon, BarsView[i].Number);
		}

		//TODO: combine? do immutable?
		public void Update(PointF center)
		{
			Hexagon = new Hexagon(Hexagon.Edge, center);

			for (var i = 0; i < 3; i++)
				BarsView[i] = new TileBarView(Hexagon, BarsView[i].Number);
		}

		private static int GetNumber(int order, Tile model)
		{
			var list = new List<int> { model.LeftNumber, model.TopNumber, model.RightNumber };
			list.Sort();
			return list[order];
		}
	}
}
