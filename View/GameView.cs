using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using TakeItEasy.Model;

namespace TakeItEasy.View
{
	public class GameView
	{
		public Color GameTileColor { get; set; }
		private readonly Dictionary<int, TileHexagonView> tiles;

		public GameView(FieldView field, Game game)
		{
			GameTileColor = Color.DeepSkyBlue;
			tiles = new Dictionary<int, TileHexagonView>();

			var fieldHexagons = new List<HexagonView>(field.GetFieldHexagons());

			foreach (var tile in game.GetTiles())
				tiles.Add(tile.Key, new TileHexagonView(fieldHexagons[tile.Key], tile.Value));
		}

		public IEnumerable<TileHexagonView> GetTileHexagons()
		{
			return tiles.Select(tile => tile.Value);
		}

		//public void AddTileHexagon(int index, Tile tile)
		//{
		//	if (index < 0 && index >= IndexMax)
		//		throw new ApplicationException($"There are only 19 cells on field. Index {index} is wrong");

		//		var hexagonView = hexagons[index];
		//	var tileHexagon = new TileHexagonView(hexagonView, tile);

		//	tileHexagon.HexagonView.Color = GameTileColor;
		//	tileHexagon.HexagonView.BorderColor = Color.Black;
		//	tileHexagon.HexagonView.BorderThickness = 0.01f;

		//	tiles.Add(index, tileHexagon);
		//}
	}
}
