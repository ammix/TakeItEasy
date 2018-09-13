//using System.Drawing;

//using TakeItEasy.Model;
//using TakeItEasy.View;

//namespace TakeItEasy.Controller
//{
//	public class TestController
//	{
//		private bool letsMove;
//		private Point clickPoint;

//		private readonly Game game;
//		private readonly GameFieldView field;
//		private readonly GameTilesView tiles;
//		private TileView selectedTileView;
//		private int selectedTilePosition;

//		public TestController(Game game, GameFieldView field, GameTilesView tiles)
//		{
//			this.game = game;
//			this.field = field;
//			this.tiles = tiles;
//		}

//		public bool OnMouseDown(Point point)
//		{
//			var position = field.GetPosition(point);
//			if (position == null) return false;

//			letsMove = true;
//			clickPoint = point;

//			//selectedTileView = gameView.GetTileHexagon(position);

//			//tiles.SelectTile(position.Value);
//			selectedTilePosition = position.Value;

//			selectedTileView = tiles.GetHexagon(selectedTilePosition);

//			return false;
//		}

//		public bool OnMouseUp(Point point)
//		{
//			letsMove = false;

//			var position = field.GetPosition(point);
//			if (position == null) return true;

//			var newPosition = field.GetPosition(point).Value;

//			if (newPosition == selectedTilePosition)
//				return false;

//			game.ChangeTilePosition(selectedTilePosition, newPosition);

//			tiles.Update();
//			return true;
//		}

//		public bool OnMouseMove(Point point)
//		{
//			if (!letsMove) return false;
//			if (selectedTileView == null) return false;

//			var vector = point - new Size(clickPoint);
//			clickPoint = point;

//			//gameView.MoveNewTile(e.Location);
//			//tiles.MoveSelectedTile(vector);
//			selectedTileView.Update(selectedTileView.Hexagon.Center + new SizeF(vector));

//			return true;
//		}

//		public bool OnMouseDoubleClick(Point point)
//		{
//			var position = field.GetPosition(point);
//			if (position == null) return false;

//			if (game.GetTile(position.Value) != null) return false;

//			game.AddTileOnField(position.Value, game.GetNextTile());
//			tiles.Update();
//			//gameTilesView.AddTileOnField(position.Value);

//			return true;
//		}
//	}
//}
