
using System.Drawing;

namespace TakeItEasy
{
	class TileHexagon : Hexagon
	{
		protected override float LineSizeRation { get; set; } = 0;

		public TileHexagon(PointF center, int edge)
			: base(center, edge) { }

		public override void Draw(Graphics g)
		{
			base.Draw(g);

			//g.FillPath(new SolidBrush(Color), path);
			////g.FillPolygon(new SolidBrush(Color.DeepPink), points);

			//g.DrawPath(new Pen(BorderColor, LineSizeRation * Edge) { EndCap = LineCap.Round }, path);
			////g.DrawLines(pen, points);
		}
	}
}
