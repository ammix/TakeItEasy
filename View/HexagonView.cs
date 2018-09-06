using System.Drawing;

namespace TakeItEasy.View
{
	public class HexagonView: HexagonStyle
	{
		public Hexagon Hexagon { get; protected set; }
		public PointF[] Vertices => Hexagon.Vertices;

		public HexagonView(float edge, PointF center)
		{
			Hexagon = new Hexagon(edge, center);

			Color = Color.White;
			BorderColor = Color.Black;
			BorderThickness = 0.01f;
		}
	}
}