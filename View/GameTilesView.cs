using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using TakeItEasy.Model;

namespace TakeItEasy.View
{
	public class GameTilesView : HexagonStyle
	{
		private readonly Dictionary<int, TileView> tiles;


		private readonly GameFieldView gameFieldView;
		private readonly Game game;
		private int selectedTileIndex;

		public GameTilesView(Game game, GameFieldView gameField, HexagonStyle style)
		{
			Color = style.Color;
			BorderColor = style.BorderColor;
			BorderThickness = style.BorderThickness;

			gameFieldView = gameField;
			this.game = game;

			tiles = new Dictionary<int, TileView>();
			selectedTileIndex = 0;

			//----------------
			var hexagon0 = gameFieldView.GetHexagon(0).Hexagon;
			var x = 1.1f * hexagon0.Edge;
			var y = 1.1f * hexagon0.Edge * 1.71f / 2f;
			var newTile = new TileView(game.NewTile, hexagon0.Edge, new PointF(x, y))
			{
				Color = Color,
				BorderColor = BorderColor,
				BorderThickness = BorderThickness
			};
			tiles.Add(-1, newTile);
			//------------------

			Update();
		}

		//public void AddTileOnFiled(int position)
		//{
		//	game.AddTileOnField(position, game.GetNextTile());
		//	UpdateView();
		//}

		//public void AddNewTile()
		//{
		//	var tile = game.GetNextTile();
		//	var tile0 = gameFieldView.GetHexagon(0);
		//	tiles.Add(-1, new TileView(tile, tile0.Hexagon.Edge, new PointF(50, 50)));
		//}

		public IEnumerable<TileView> GetTileHexagons()
		{
			return tiles.Select(x => x.Value);
		}

		public void Update()
		{
			var newTileCenter = tiles[-1].Hexagon.Center;

			tiles.Clear();

			var hexagon0 = gameFieldView.GetHexagon(0).Hexagon;
			var newTile = new TileView(game.NewTile, hexagon0.Edge, newTileCenter)
			{
				Color = Color,
				BorderColor = BorderColor,
				BorderThickness = BorderThickness
            };

			tiles.Add(-1, newTile);

			foreach (var tile in game.GetTiles())
			{
				var hexagon = gameFieldView.GetHexagon(tile.Key).Hexagon;
				var tileView = new TileView(tile.Value, hexagon.Edge, hexagon.Center)
				{
					Color = Color,
					BorderColor = BorderColor,
					BorderThickness = BorderThickness
				};

				tiles.Add(tile.Key, tileView);
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
				tileView.Update(tileView.Hexagon.Center + new Size(vector));
			}
		}

		public TileView GetHexagon(int index)
		{
			return tiles[index];
		}
	}
}
