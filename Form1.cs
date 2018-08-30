using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TakeItEasy.Model;

namespace TakeItEasy
{
	public partial class Form1 : Form
	{
		//private readonly GameField gameField;
		private readonly List<bool> model;

		public Form1()
		{
			InitializeComponent();
			//gameField = new GameField();

			model = new List<bool>();
			for (var i = 0; i < 19; i++)
				model.Add(false);
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

			RenderEngine.DrawGameField(e.Graphics, ClientSize, model);

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


			//var k = (float)Math.Sqrt(3);
			//e.Graphics.DrawEllipse(new Pen(Color.Black, 1), c.X-k*a/2, c.Y-k*a/2, k*a, k*a);
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			//gameField.Click(e.Location);
			Invalidate();
		}
	}
}
