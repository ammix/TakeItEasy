using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TakeItEasy.Model;

namespace TakeItEasy.View
{
	public class GameView
	{
		public Color TileColor { get; }
		public Color TileBorderColor { get; }
		public float TileBorderThickness { get; }

		private Dictionary<int, TileHexagonView> tiles;
		private readonly FieldView fieldView;
		private readonly Game game;
		private int selectedTileIndex;

		public GameView(Game game, FieldView field, Color tileColor, Color tileBorderColor, float tileBorderThickness)
		{
			TileColor = tileColor;
			TileBorderColor = tileBorderColor;
			TileBorderThickness = tileBorderThickness;

			fieldView = field;
			this.game = game;

			//tiles = new Dictionary<int, TileHexagonView>();
			selectedTileIndex = 0;
			Update();
		}

		//public void AddTileOnFiled(int position)
		//{
		//	game.AddTileOnField(position, game.GetNextTile());
		//	UpdateView();
		//}

		public IEnumerable<TileHexagonView> GetTileHexagons()
		{
			return tiles.Select(x=>x.Value);
		}

		public void Update()
		{
			//tiles = new List<TileHexagonView>();
			tiles = new Dictionary<int, TileHexagonView>();

			var fieldHexagons = new List<HexagonView>(fieldView.GetFieldHexagons());

			foreach (var tile in game.GetTiles())
			{
				var hx0 = fieldHexagons[tile.Key];
				var hx1 = new HexagonView(hx0.Edge, hx0.Center);


				//var tileHagaonView = new TileHexagonView(hx1, tile.Value);
				var tileHagaonView = new TileHexagonView(fieldHexagons[tile.Key], tile.Value);

				tileHagaonView.HexagonView.Color = TileColor;
				tileHagaonView.HexagonView.BorderColor = TileBorderColor;
				tileHagaonView.HexagonView.BorderThickness = TileBorderThickness;

				tiles.Add(tile.Key, tileHagaonView);
			}
		}

		public void SelectTile(int position)
		{
			selectedTileIndex = position;
		}

		public void MoveSelectedTile(Point vector)
		{
			if (tiles.ContainsKey(selectedTileIndex))
			{
				var tile = tiles[selectedTileIndex];

				//var hx = tile.HexagonView;
				//hx.Center = tile.HexagonView.Center + new Size(vector);
				tile.HexagonView.Center = tile.HexagonView.Center + new Size(vector);
				//tile.HexagonView = hx;

				tiles[selectedTileIndex] = tile;
			}
		}
	}
}
