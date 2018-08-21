using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TakeItEasy
{
	public partial class Form1 : Form
	{
		private readonly GameField gameField;
		private readonly List<bool> model;

		public Form1()
		{
			InitializeComponent();
			gameField = new GameField();

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


			var hexagon = new TileHexagon(c, a);
			hexagon.BorderColor = Color.Black;
			hexagon.Color = Color.Pink;
			hexagon.Draw(e.Graphics);


			//var k = (float)Math.Sqrt(3);
			//e.Graphics.DrawEllipse(new Pen(Color.Black, 1), c.X-k*a/2, c.Y-k*a/2, k*a, k*a);
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			gameField.Click(e.Location);
			Invalidate();
		}
	}
}
