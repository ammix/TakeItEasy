using System;
using System.Drawing;
using System.Windows.Forms;
using TakeItEasy.Controller;
using TakeItEasy.Model;
using TakeItEasy.View;

namespace TakeItEasy
{
	public partial class MainWindow : Form
	{
		private readonly Game game;

		private readonly GameFieldView gameFieldView;
		private readonly GameTilesView gameTilesView;

		private TilesMoverController controller;

		private bool letsMove;
		private Point clickPoint;

		public MainWindow()
		{
			game = new Game();
			//gameTilesView.AddNewTile();
			game.AddNewTile();

			gameFieldView = new GameFieldView(ClientSize, new HexagonStyle(Color.DeepPink, Color.Pink, 0.05f));
			gameTilesView = new GameTilesView(game, gameFieldView, new HexagonStyle(Color.DeepSkyBlue, Color.Black, 0.01f));

			InitializeComponent();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			gameFieldView.Size = ClientSize;
			gameTilesView.Update();

			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			RenderEngine.DrawFieldView(e.Graphics, gameFieldView);
			RenderEngine.DrawGameView(e.Graphics, gameTilesView);
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			//var position = fieldView.GetPosition(e.Location);
			////if (!game.IsPositionFree(position))
			//var tile = game.GetNextTile();

			//if (position != null)
			//	game.AddTileOnField(position.Value, tile);

			//Invalidate();

			letsMove = false;
			var position = gameFieldView.GetPosition(e.Location);
			if (position == null)
			{
				Invalidate();
				return;
			}

			gameTilesView.SetSelectedTile(position.Value);
			gameTilesView.Update();

			Invalidate();
		}

		private void FormController_MouseDown(object sender, MouseEventArgs e)
		{
			var position = gameFieldView.GetPosition(e.Location);
			if (position == null) return;

			letsMove = true;
			clickPoint = e.Location;

			//selectedTileView = gameView.GetTileHexagon(position);

			gameTilesView.SelectTile(position.Value);

		}

		private void FormController_MouseMove(object sender, MouseEventArgs e)
		{
			if (letsMove)
			{
				//selectedTileView.HexagonView.Center = new PointF(0, 0);

				var vector = e.Location - new Size(clickPoint);
				clickPoint = e.Location;
				//gameView.MoveNewTile(e.Location);

				gameTilesView.MoveSelectedTile(vector);

				Invalidate();
			}
		}

		private void FormController_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var position = gameFieldView.GetPosition(e.Location);
			if (position == null) return;

			if (game.GetTile(position.Value) != null) return;

			game.AddTileOnField(position.Value, game.GetNextTile());
			gameTilesView.Update();
			//gameTilesView.AddTileOnField(position.Value);

			Invalidate();
		}
	}
}
