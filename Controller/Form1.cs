using System;
using System.Windows.Forms;
using TakeItEasy.Model;
using TakeItEasy.View;

namespace TakeItEasy
{
	public partial class Form1 : Form
	{
		//private readonly GameField gameField;
		private readonly Game game;

		private FieldView fieldView;

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

			fieldView = new FieldView(ClientSize);
			var gameView = new GameView(fieldView, game);

			RenderEngine.DrawGameField(e.Graphics, fieldView, gameView);

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

			var tile = new Tile(9, 8, 7);

			var tileHexagonView = new TileHexagonView(hexagonView, tile);
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
			var tile = game.GetNextTile();
			game.AddTileOnField(1, tile);

			Invalidate();
		}
	}
}
