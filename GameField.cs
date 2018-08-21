using System;
using System.Collections.Generic;
using System.Drawing;

namespace TakeItEasy
{
	public class GameField
	{
		private readonly List<Hexagon> hexagons;

		public GameField()
		{
			//var color = Color.DeepPink;
			var color = Color.DeepSkyBlue;
			var borderColor = Color.LightPink;

			hexagons = new List<Hexagon>();
			for (var i = 0; i < 19; i++)
			{
				var hexagon = new TileHexagon(new PointF(), 0);
				hexagon.Color = color;
				hexagon.BorderColor = borderColor;
				hexagons.Add(hexagon);
			}
		}

		public void Draw(Graphics g, SizeF size)
		{
			var c = new PointF(size.Width / 2f, size.Height / 2f);
			var a = Math.Min(size.Width, size.Height) / 9;
			var dy = (float)Math.Sqrt(3) * a;

			hexagons[0].Set(new PointF(c.X + 3 * a, c.Y + dy), a);
			hexagons[1].Set(new PointF(c.X + 3 * a, c.Y), a);
			hexagons[2].Set(new PointF(c.X + 3 * a, c.Y - dy), a);

			hexagons[3].Set(new PointF(c.X + 1.5f * a, c.Y + 1.5f * dy), a);
			hexagons[4].Set(new PointF(c.X + 1.5f * a, c.Y + 0.5f * dy), a);
			hexagons[5].Set(new PointF(c.X + 1.5f * a, c.Y - 0.5f * dy), a);
			hexagons[6].Set(new PointF(c.X + 1.5f * a, c.Y - 1.5f * dy), a);

			hexagons[7].Set(new PointF(c.X, c.Y + 2 * dy), a);
			hexagons[8].Set(new PointF(c.X, c.Y + dy), a);
			hexagons[9].Set(new PointF(c.X, c.Y), a);
			hexagons[10].Set(new PointF(c.X, c.Y - dy), a);
			hexagons[11].Set(new PointF(c.X, c.Y - 2 * dy), a);

			hexagons[12].Set(new PointF(c.X - 1.5f * a, c.Y + 1.5f * dy), a);
			hexagons[13].Set(new PointF(c.X - 1.5f * a, c.Y + 0.5f * dy), a);
			hexagons[14].Set(new PointF(c.X - 1.5f * a, c.Y - 0.5f * dy), a);
			hexagons[15].Set(new PointF(c.X - 1.5f * a, c.Y - 1.5f * dy), a);

			hexagons[16].Set(new PointF(c.X - 3 * a, c.Y + dy), a);
			hexagons[17].Set(new PointF(c.X - 3 * a, c.Y), a);
			hexagons[18].Set(new PointF(c.X - 3 * a, c.Y - dy), a);

			g.Clear(Color.Black);
			foreach (var hexagon in hexagons)
				hexagon.Draw(g);
		}

		public void Click(PointF point)
		{
			foreach (var hexagon in hexagons)
			{
				if (hexagon.Contains(point))
					if (hexagon.Color != Color.White)
						hexagon.Color = Color.White;
					else
						hexagon.Color = Color.DeepPink;
			}
		}
	}
}
