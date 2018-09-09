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
		private readonly GameFieldView gameFieldView;
		private readonly GameTilesView gameTilesView;

		private readonly Controller.Controller controller;


		public MainWindow()
		{
			var game = new Game();
			game.AddNewTile();

			//gameTilesView.AddNewTile();

			gameFieldView = new GameFieldView(ClientSize, new HexagonStyle(Color.DeepPink, Color.Pink, 0.05f));
			gameTilesView = new GameTilesView(game, gameFieldView, new HexagonStyle(Color.DeepSkyBlue, Color.Black, 0.01f));

			controller = new Controller.Controller(game, gameFieldView, gameTilesView);

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
