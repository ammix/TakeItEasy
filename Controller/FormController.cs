using System;
using System.Drawing;
using System.Windows.Forms;

using TakeItEasy.Model;
using TakeItEasy.View;

namespace TakeItEasy.Controller
{
	public partial class FormController : Form
	{
		private readonly Game game;

		private FieldView fieldView;
		private GameView gameView;

		private bool letsMove;
		private Point clickPoint;
		//private TileHexagonView selectedTileView;

		public FormController()
		{
			game = new Game();

			fieldView = new FieldView(ClientSize, Color.DeepPink, Color.Pink, 0.05f);
			gameView = new GameView(game, fieldView, Color.DeepSkyBlue, Color.Black, 0.01f);

			InitializeComponent();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			//fieldView.Size = ClientSize;
			fieldView.Update(ClientSize);
			gameView.Update();

			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			RenderEngine.DrawFieldView(e.Graphics, fieldView);
			RenderEngine.DrawGameView(e.Graphics, gameView);
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
			var position = fieldView.GetPosition(e.Location);
			if (position == null)
			{
				Invalidate();
				return;
			}

			gameView.SetSelectedTile(position.Value);
			gameView.Update();

			Invalidate();
		}

		private void FormController_MouseDown(object sender, MouseEventArgs e)
		{
			var position = fieldView.GetPosition(e.Location);
			if (position == null) return;

			letsMove = true;
			clickPoint = e.Location;
			//selectedTileView = gameView.GetTileHexagon(position);

			gameView.SelectTile(position.Value);

		}

		private void FormController_MouseMove(object sender, MouseEventArgs e)
		{
			if (letsMove)
			{
				//selectedTileView.HexagonView.Center = new PointF(0, 0);

				var vector = e.Location - new Size(clickPoint);
				clickPoint = e.Location;
				//gameView.MoveNewTile(e.Location);
				gameView.MoveSelectedTile(vector);

				Invalidate();
			}
		}

		private void FormController_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var position = fieldView.GetPosition(e.Location);
			if (position == null) return;

			if (game.GetTile(position.Value) != null) return;

			var tile = game.GetNextTile();
			game.AddTileOnField(position.Value, tile);
			gameView.Update();

			Invalidate();
		}
	}
}
