using System;
using System.Windows.Forms;

namespace TakeItEasy
{
	public partial class Form1 : Form
	{
		//private readonly GameField gameField;
		private readonly Game game;

		public Form1()
		{
			InitializeComponent();
			game = new Game();
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			//gameField.Draw(e.Graphics, ClientSize);

			RenderEngine.DrawGameField(e.Graphics, ClientSize, game);

			//RenderEngine.DrawGame(e.Graphics, ClientSize, model);

			/*
			var c = new PointF(ClientSize.Width / 2f, ClientSize.Height / 2f);
			var a = Math.Min(ClientSize.Width, ClientSize.Height) / 9;


			//var hexagon = new TileHexagon(c, a);
			//hexagon.BorderColor = Color.Black;
			//hexagon.Color = Color.Pink;
			//hexagon.Draw(e.Graphics);


			var hexagonView = new HexagonView(a, c);
			hexagonView.Color = Color.DeepSkyBlue;
			hexagonView.BorderThickness = 0.01f;
			hexagonView.BorderColor = Color.Black;

			var tileModel = new TileModel(9, 8, 7);

			var tileHexagonView = new TileHexagonView(hexagonView, tileModel);
			RenderEngine.DrawTileHexagon(e.Graphics, tileHexagonView);
			*/
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			//gameField.Click(e.Location);
			Invalidate();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			game.GetNextTile();
			Invalidate();
		}
	}
}
