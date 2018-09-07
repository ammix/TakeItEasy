using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeItEasy.Model;
using TakeItEasy.View;

namespace TakeItEasy.Controller
{
	public class TestController
	{
		private bool letsMove;
		private Point clickPoint;

		private Game game;
		private GameFieldView field;
		private GameTilesView tiles;

		public TestController(Game game, GameFieldView field, GameTilesView tiles)
		{
			this.game = game;
			this.field = field;
			this.tiles = tiles;
		}

		public void OnMouseDown(Point point)
		{
			var position = field.GetPosition(point);
			if (position == null) return;

			letsMove = true;
			clickPoint = point;

			//selectedTileView = gameView.GetTileHexagon(position);

			tiles.SelectTile(position.Value);
		}

		public void OnMouseUp(Point point)
		{
			letsMove = false;

			var position = field.GetPosition(point);
			if (position == null) return;


			tiles.SetSelectedTile(position.Value);
			tiles.Update();
		}

		public bool OnMouseMove(Point point)
		{
			if (!letsMove) return false;
			//selectedTileView.HexagonView.Center = new PointF(0, 0);

			var vector = point - new Size(clickPoint);
			clickPoint = point;
			//gameView.MoveNewTile(e.Location);

			tiles.MoveSelectedTile(vector);

			return true;
			//Invalidate();
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
