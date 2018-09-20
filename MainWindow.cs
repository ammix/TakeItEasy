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
		private readonly GameView gameView;

		private readonly GameController controller;


		public MainWindow()
		{
			game = new Game();
			game.StartNew();
			game.AddNewTile();

			gameView = new GameView(game,
				new HexagonStyle(Color.HotPink, Color.Pink, 0.05f),
				new HexagonStyle(Color.DeepSkyBlue, Color.Black, 0.01f));
			gameView.Update(ClientSize); //TODO: remove this?

			controller = new GameController(game, gameView);

			InitializeComponent();
			WindowState = FormWindowState.Maximized;
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
			if (e.Button != MouseButtons.Left) return;

			if (controller.OnLeftMouseDown(e.Location))
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

		private void MainWindow_Load(object sender, EventArgs e)
		{
			//gameView.AddNewTile(game.NewTile);
		}

		private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
		{
			game.StartNew();
			game.AddNewTile();

			gameView.AddNewTile(game.NewTile);
			gameView.Update();

			Invalidate();
		}

		private void blueToolStripMenuItem_Click(object sender, EventArgs e)
		{
			gameView.FieldStyle = new HexagonStyle(Color.DeepSkyBlue, Color.Aqua, 0.05f);
			//gameView.Update(); this is not needed...

			Invalidate();
		}

		private void pinkToolStripMenuItem_Click(object sender, EventArgs e)
		{
			gameView.FieldStyle = new HexagonStyle(Color.HotPink, Color.Pink, 0.05f);
			Invalidate();
		}

		private void yellowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			gameView.FieldStyle = new HexagonStyle(Color.Yellow, Color.Orange, 0.05f);
			Invalidate();
		}

		private void turquoiseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			gameView.FieldStyle = new HexagonStyle(Color.Violet, Color.Fuchsia, 0.05f);
			Invalidate();
		}
	}
}
