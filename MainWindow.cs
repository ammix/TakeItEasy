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
		private readonly GameView gameView;

		private readonly GameController controller;


		public MainWindow()
		{
			var game = new Game();
			game.AddNewTile();
			//gameTilesView.AddNewTile();

			gameView = new GameView(game,
				new HexagonStyle(Color.DeepPink, Color.Pink, 0.05f),
				new HexagonStyle(Color.DeepSkyBlue, Color.Black, 0.01f));
			gameView.Update(ClientSize); //TODO: remove this?
			gameView.AddNewTile(game.NewTile);

			controller = new GameController(game, gameView);

			InitializeComponent();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			gameView.Update(ClientSize);

			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			RenderEngine.DrawGameView(e.Graphics, gameView);
		}

		private void MainWindow_MouseUp(object sender, MouseEventArgs e)
		{
			if (controller.OnMouseUp(e.Location))
				Invalidate();
		}

		private void MainWindow_MouseDown(object sender, MouseEventArgs e)
		{
			if (controller.OnMouseDown(e.Location))
				Invalidate();
		}

		private void FormController_MouseMove(object sender, MouseEventArgs e)
		{
			if (controller.OnMouseMove(e.Location))
				Invalidate();
		}

		private void FormController_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (controller.OnMouseDoubleClick(e.Location))
				Invalidate();
		}
	}
}
