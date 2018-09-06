using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using TakeItEasy.Model;
using TakeItEasy.Rendering;

namespace TakeItEasy.View
{
	public class GameView
	{
		public Color TileColor { get; }
		public Color TileBorderColor { get; }
		public float TileBorderThickness { get; }

		private Dictionary<int, TileGraphics> tiles;
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

		public IEnumerable<TileGraphics> GetTileHexagons()
		{
			return tiles.Select(x => x.Value);
		}

		public void Update()
		{
			tiles = new Dictionary<int, TileGraphics>();

			foreach (var tile in game.GetTiles())
			{
				var tileGraphics = new TileGraphics(fieldView.GetHexagon(tile.Key).Hexagon, tile.Value);

				tileGraphics.Color = TileColor;
				tileGraphics.BorderColor = TileBorderColor;
				tileGraphics.BorderThickness = TileBorderThickness;

				tiles.Add(tile.Key, tileGraphics);
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

		//public void MoveSelectedTile(Point vector)
		//{
		//	if (tiles.ContainsKey(selectedTileIndex))
		//	{
		//		var tileView = tiles[selectedTileIndex];
		//		tileView.HexagonView.Center = tileView.HexagonView.Center + new Size(vector);
		//		tiles[selectedTileIndex] = tileView;
		//	}
		//}
	}
}
