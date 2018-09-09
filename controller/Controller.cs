using System.Drawing;

using TakeItEasy.Model;
using TakeItEasy.View;

namespace TakeItEasy.Controller
{
	public class Controller
	{
		private bool isMoveRegime;
		private Point currentPoint;

		private readonly Game game;
		private readonly GameFieldView field;
		private readonly GameTilesView tiles;

		public Controller(Game game, GameFieldView field, GameTilesView tiles)
		{
			this.game = game;
			this.field = field;
			this.tiles = tiles;
		}

		public bool OnMouseDown(Point point)
		{
			var newTileView = tiles.GetHexagon(-1);
			if (newTileView.Contains(point))
			{
				isMoveRegime = true;
				currentPoint = point;

				tiles.SelectTile(-1);
			}
			return false;
		}

		public bool OnMouseUp(Point point)
		{
			isMoveRegime = false;
			return false;

			//var position = field.GetPosition(point);
			//if (position == null) return true;

			//tiles.SetSelectedTile(position.Value);
			//tiles.Update();
			//return true;
		}

		public bool OnMouseMove(Point point)
		{
			if (!isMoveRegime) return false;

			var vector = point - new Size(currentPoint);
			currentPoint = point;
			//gameView.MoveNewTile(e.Location);

			tiles.MoveSelectedTile(vector);

			return true;
		}

		public bool OnMouseDoubleClick(Point point)
		{
			//var position = field.GetPosition(point);
			//if (position == null) return false;

			//if (game.GetTile(position.Value) != null) return false;

			//game.AddTileOnField(position.Value, game.GetNextTile());
			//tiles.Update();
			////gameTilesView.AddTileOnField(position.Value);

			//return true;

			return false;
		}
	}
}
