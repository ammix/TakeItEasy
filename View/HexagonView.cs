using System.Drawing;
using System.Drawing.Drawing2D;

namespace TakeItEasy.View
{
	public class HexagonView
	{
		public Hexagon Hexagon { get; protected set; }
		public HexagonStyle HexagonStyle { get; protected set; }
		public PointF[] Vertices => Hexagon.Vertices;

		//TODO: remove this
		protected HexagonView(float edge, PointF center)
		{
			Hexagon = new Hexagon(edge, center);

			//Color = Color.White;
			//BorderColor = Color.Black;
			//BorderThickness = 0.01f;
		}

		public HexagonView(float edge, PointF center, HexagonStyle style)
			: this(edge, center)
		{
			HexagonStyle = style;
		}

		public bool Contains(Point point)
		{
			using (var graphicsPath = new GraphicsPath())
			{
				graphicsPath.AddLines(Hexagon.Vertices);
				if (graphicsPath.IsVisible(point))
					return true;
			}
			return false;
		}
	}
}