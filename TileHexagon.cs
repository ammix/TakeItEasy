//using System;
//using System.Drawing;
//using System.Drawing.Drawing2D;

//namespace TakeItEasy
//{
//	public class TileHexagon : Hexagon
//	{
//		protected override float LineSizeRation { get; set; } = 0;

//		public TileHexagon(PointF center, int edge)
//			: base(center, edge) { }

//		public override void Draw(Graphics g)
//		{
//			base.Draw(g);

//			//g.FillPath(new SolidBrush(Color), path);
//			////g.FillPolygon(new SolidBrush(Color.DeepPink), points);

//			//g.DrawPath(new Pen(BorderColor, LineSizeRation * Edge) { EndCap = LineCap.Round }, path);
//			////g.DrawLines(pen, points);

//			var a = Edge;
//			var b = a * 15 / 62;
//			var sqrt3 = (float) Math.Sqrt(3);
//			var c = new SizeF(Center);

//			var p1 = new PointF(b / 2, a * sqrt3 / 2);
//			var p2 = new PointF(a * 3 / 4 - b / 4, a * sqrt3 / 4 + b * sqrt3 / 4);
//			var p3 = new PointF(a * 3 / 4 + b / 4, a * sqrt3 / 4 - b * sqrt3 / 4);
//			var p4 = new PointF(a * 3 / 4 + b / 4, -a * sqrt3 / 4 + b * sqrt3 / 4);
//			var p5 = new PointF(a * 3 / 4 - b / 4, -a * sqrt3 / 4 - b * sqrt3 / 4);
//			var p6 = new PointF(b / 2, -a * sqrt3 / 2);
//			var p7 = new PointF(-b / 2, -a * sqrt3 / 2);
//			var p8 = new PointF(-a * 3 / 4 + b / 4, -a * sqrt3 / 4 - b * sqrt3 / 4);
//			var p9 = new PointF(-a * 3 / 4 - b / 4, -a * sqrt3 / 4 + b * sqrt3 / 4);
//			var p10 = new PointF(-a * 3 / 4 - b / 4, a * sqrt3 / 4 - b * sqrt3 / 4);
//			var p11 = new PointF(-a * 3 / 4 + b / 4, a * sqrt3 / 4 + b * sqrt3 / 4);
//			var p12 = new PointF(-b / 2, a * sqrt3 / 2);

//			var bar1 = new GraphicsPath();
//			bar1.AddLines(new[] {p12 + c, p1 + c, p6 + c, p7 + c, p12 + c});

//			var bar2 = new GraphicsPath();
//			bar2.AddLines(new[] {p2 + c, p3 + c, p8 + c, p9 + c, p2 + c});

//			var bar3 = new GraphicsPath();
//			bar3.AddLines(new[] {p4 + c, p5 + c, p10 + c, p11 + c, p4 + c});

//			g.FillPath(new SolidBrush(Color.LimeGreen), bar3);
//			g.DrawPath(new Pen(Color.Black), bar3);
//			g.DrawString("7", new Font("Arial", b, FontStyle.Regular), new SolidBrush(Color.Black), Center.X - p4.X+b/5, Center.Y - p4.Y - b / 2);

//			g.FillPath(new SolidBrush(Color.Orange), bar2);
//			g.DrawPath(new Pen(Color.Black), bar2);
//			g.DrawString("8", new Font("Arial", b, FontStyle.Regular), new SolidBrush(Color.Black), Center.X - p9.X - b * 1.25f, Center.Y - p9.Y - b / 2);

//			g.FillPath(new SolidBrush(Color.Yellow), bar1);
//			g.DrawPath(new Pen(Color.Black), bar1);
//			g.DrawString("9", new Font("Arial", b, FontStyle.Regular), new SolidBrush(Color.Black), Center.X - b/1.75f, Center.Y - a * sqrt3 / 2);
//		}
//	}
//}
