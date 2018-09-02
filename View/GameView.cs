using System.Collections.Generic;
using System.Drawing;

using TakeItEasy.Model;

namespace TakeItEasy.View
{
	public class GameView
	{
		public Color TileColor { get; }
		public Color TileBorderColor { get; }
		public float TileBorderThickness { get; }

		//private readonly Dictionary<int, TileHexagonView> tiles;
		private readonly List<TileHexagonView> tiles;

		public GameView(Game game, FieldView field, Color tileColor, Color tileBorderColor, float tileBorderThickness)
		{
			TileColor = tileColor;
			TileBorderColor = tileBorderColor;
			TileBorderThickness = tileBorderThickness;

			//tiles = new Dictionary<int, TileHexagonView>();
			tiles = new List<TileHexagonView>();

			var fieldHexagons = new List<HexagonView>(field.GetFieldHexagons());
			foreach (var tile in game.GetTiles())
			{
				var tileHagaonView = new TileHexagonView(fieldHexagons[tile.Key], tile.Value);
				tileHagaonView.HexagonView.Color = TileColor;
				tileHagaonView.HexagonView.BorderColor = tileBorderColor;
				tileHagaonView.HexagonView.BorderThickness = tileBorderThickness;
				//tiles.Add(tile.Key, tileHagaonView);
				tiles.Add(tileHagaonView);
			}
		}

		public IEnumerable<TileHexagonView> GetTileHexagons()
		{
			//return tiles.Select(tile => tile.Value);
			return tiles;
		}
	}
}
