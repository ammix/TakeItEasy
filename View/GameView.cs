using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

			foreach (var tile in game.GetTiles())
			{
				var hexagonView = new HexagonView(fieldView.GetHexagon(tile.Key));
				var tileHagaonView = new TileHexagonView(hexagonView, tile.Value);

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

		public void SetSelectedTile(int newPosition)
		{
			if (newPosition == selectedTileIndex)
				return;
			game.ChangeTilePosition(selectedTileIndex, newPosition);
		}

		public void MoveSelectedTile(Point vector)
		{
			if (tiles.ContainsKey(selectedTileIndex))
			{
				var tileView = tiles[selectedTileIndex];

				//var hx = tile.HexagonView;
				//hx.Center = tile.HexagonView.Center + new Size(vector);
				tileView.HexagonView.Center = tileView.HexagonView.Center + new Size(vector);
				//tile.HexagonView = hx;

				//var x = tileView.HexagonView;
				//var newCenter = x.Center + new SizeF(vector);
				//var newX = new HexagonView(x, newCenter);

				//tiles[selectedTileIndex] = new TileHexagonView(x, tileView.Tile);
				tiles[selectedTileIndex] = tileView;
			}
		}
	}
}
