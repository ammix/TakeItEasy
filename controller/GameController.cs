using System.Drawing;

using TakeItEasy.Model;
using TakeItEasy.View;

namespace TakeItEasy.Controller
{
	public class GameController
	{
		private bool isMoveRegime;
		private Point currentPoint;
		private TileView newTileView;

		private readonly Game game;
		private readonly GameView gameView;

		public GameController(Game game, GameView gameView)
		{
			this.game = game;
			this.gameView = gameView;
		}

		public bool OnLeftMouseDown(Point point)
		{
			//TODO: gameView.FreeTile
			newTileView = gameView.FreeTile;
			if (newTileView !=null && newTileView.Contains(point))
			{
				isMoveRegime = true;
				currentPoint = point;

				//tiles.SelectTile(-1);
				//tileToMove = tiles.GetHexagon(-1);
			}
			return false;
		}

		public bool OnMouseUp(Point point)
		{
			if (!isMoveRegime)
				return false;

			isMoveRegime = false;

			var position = gameView.GetPosition(point);
			if (position == null)
				return false;

			var updateFlag = gameView.AddTileOnField(position.Value, newTileView);

			return updateFlag;

			//var position = field.GetPosition(point);
			//if (position == null) return true;

			//tiles.SetNewPositionToSelectedTile(position.Value);
			//tiles.Update();
			//return true;
		}

		public bool OnMouseMove(Point point)
		{
			if (!isMoveRegime) return false;

			var vector = point - new Size(currentPoint);
			currentPoint = point;
			//gameView.MoveNewTile(e.Location);

			newTileView.Update(newTileView.Hexagon.Center + new SizeF(vector));

			return true;
		}

		public bool OnMouseDoubleClick(Point point)
		{
			var position = gameView.GetPosition(point);
			if (position == null)
				return false;

			if (!game.AddTileOnField(position.Value, newTileView.Tile))
				return false;

			gameView.Update();

			game.AddNewTile();
			gameView.AddNewTile(game.NewTile);

			return true;
		}
	}
}
