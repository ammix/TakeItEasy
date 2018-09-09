using System.Drawing;

using TakeItEasy.Model;
using TakeItEasy.View;

namespace TakeItEasy.Controller
{
	public class TestController
	{
		private bool letsMove;
		private Point clickPoint;

		private readonly Game game;
		private readonly GameFieldView field;
		private readonly GameTilesView tiles;

		public TestController(Game game, GameFieldView field, GameTilesView tiles)
		{
			this.game = game;
			this.field = field;
			this.tiles = tiles;
		}

		public bool OnMouseDown(Point point)
		{
			var position = field.GetPosition(point);
			if (position == null) return false;

			letsMove = true;
			clickPoint = point;

			//selectedTileView = gameView.GetTileHexagon(position);

			tiles.SelectTile(position.Value);
			return false;
		}

		public bool OnMouseUp(Point point)
		{
			letsMove = false;

			var position = field.GetPosition(point);
			if (position == null) return true;


			tiles.SetSelectedTile(position.Value);
			tiles.Update();
			return true;
		}

		public bool OnMouseMove(Point point)
		{
			if (!letsMove) return false;

			var vector = point - new Size(clickPoint);
			clickPoint = point;
			//gameView.MoveNewTile(e.Location);

			tiles.MoveSelectedTile(vector);

			return true;
		}

		public bool OnMouseDoubleClick(Point point)
		{
			var position = field.GetPosition(point);
			if (position == null) return false;

			if (game.GetTile(position.Value) != null) return false;

			game.AddTileOnField(position.Value, game.GetNextTile());
			tiles.Update();
			//gameTilesView.AddTileOnField(position.Value);

			return true;
		}
	}
}
