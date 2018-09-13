using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;

using TakeItEasy.Model;

namespace TakeItEasy.View
{
	public class GameView
	{
		private Dictionary<int, HexagonView> fieldHexagons;
		private Dictionary<int, TileView> gameTiles;
		private HexagonStyle fieldHexagonStyle;
		private HexagonStyle tilesHexagonStyle;

		private Game game;

		public GameView(Game game, HexagonStyle fieldHexagonStyle, HexagonStyle tilesHexagonStyle)
		{
			this.game = game;

			this.fieldHexagonStyle = fieldHexagonStyle;
			this.tilesHexagonStyle = tilesHexagonStyle;
		}

		public TileView FreeTile { get; private set; }

		public void AddNewTile(Tile tile)
		{
			var a = fieldHexagons[0].Hexagon.Edge;

			//TODO: define initial tile position
			FreeTile = new TileView(tile, fieldHexagons[0].Hexagon.Edge, new PointF(2*a, a * (float)Math.Sqrt(3)), tilesHexagonStyle);
		}

		public void Update()
		{
			//TODO: code duplicate
			gameTiles = new Dictionary<int, TileView>();
			foreach (var tile in game.GetTiles())
			{
				var fieldHexagon = fieldHexagons[tile.Key].Hexagon;
				var tileView = new TileView(tile.Value, fieldHexagon.Edge/*a*/, fieldHexagon.Center, tilesHexagonStyle);

				gameTiles.Add(tile.Key, tileView);
			}
		}

		public void Update(SizeF size)
		{
			var center = new PointF(size.Width / 2f, size.Height / 2f);
			var c = new SizeF(center);
			var a = Math.Min(size.Width, size.Height) / 9;

			var sqrt3 = (float)Math.Sqrt(3);

			fieldHexagons = new Dictionary<int, HexagonView>
			{
				{0, new HexagonView(a, new PointF(3 * a, sqrt3 * a) + c, fieldHexagonStyle)},
				{1, new HexagonView(a, new PointF(3 * a, 0) + c, fieldHexagonStyle)},
				{2, new HexagonView(a, new PointF(3 * a, -sqrt3 * a) + c, fieldHexagonStyle)},

				{3, new HexagonView(a, new PointF(1.5f * a, 1.5f * sqrt3 * a) + c, fieldHexagonStyle)},
				{4, new HexagonView(a, new PointF(1.5f * a, 0.5f * sqrt3 * a) + c, fieldHexagonStyle)},
				{5, new HexagonView(a, new PointF(1.5f * a, -0.5f * sqrt3 * a) + c, fieldHexagonStyle)},
				{6, new HexagonView(a, new PointF(1.5f * a, -1.5f * sqrt3 * a) + c, fieldHexagonStyle)},

				{7, new HexagonView(a, new PointF(0, 2 * sqrt3 * a) + c, fieldHexagonStyle)},
				{8, new HexagonView(a, new PointF(0, sqrt3 * a) + c, fieldHexagonStyle)},
				{9, new HexagonView(a, new PointF(0, 0) + c, fieldHexagonStyle)},
				{10, new HexagonView(a, new PointF(0, -sqrt3 * a) + c, fieldHexagonStyle)},
				{11, new HexagonView(a, new PointF(0, -2 * sqrt3 * a) + c, fieldHexagonStyle)},

				{12, new HexagonView(a, new PointF(-1.5f * a, 1.5f * sqrt3 * a) + c, fieldHexagonStyle)},
				{13, new HexagonView(a, new PointF(-1.5f * a, 0.5f * sqrt3 * a) + c, fieldHexagonStyle)},
				{14, new HexagonView(a, new PointF(-1.5f * a, -0.5f * sqrt3 * a) + c, fieldHexagonStyle)},
				{15, new HexagonView(a, new PointF(-1.5f * a, -1.5f * sqrt3 * a) + c, fieldHexagonStyle)},

				{16, new HexagonView(a, new PointF(-3 * a, sqrt3 * a) + c, fieldHexagonStyle)},
				{17, new HexagonView(a, new PointF(-3 * a, 0) + c, fieldHexagonStyle)},
				{18, new HexagonView(a, new PointF(-3 * a, -sqrt3 * a) + c, fieldHexagonStyle)}
			};

			gameTiles = new Dictionary<int, TileView>();
            foreach (var tile in game.GetTiles())
            {
	            var fieldHexagon = fieldHexagons[tile.Key].Hexagon;
	            var tileView = new TileView(tile.Value, fieldHexagon.Edge/*a*/, fieldHexagon.Center, tilesHexagonStyle);

				gameTiles.Add(tile.Key, tileView);
			}

			//TODO: Consider Update _vs_ create new
			//freeTile = new TileView(game.NewTile/*freeTile.Tile*/, a, freeTile.Hexagon.Center, tilesHexagonStyle);
			FreeTile?.Update(a);
		}

		public int? GetPosition(Point point)
		{
			foreach (var h in fieldHexagons)
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

		public IEnumerable<HexagonView> GetFieldHexagons()
		{
			return fieldHexagons.Select(x => x.Value);
		}

		public IEnumerable<TileView> GetTileHexagons()
		{
			return gameTiles.Select(x => x.Value);
		}
	}
}
