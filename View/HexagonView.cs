using System.Drawing;

namespace TakeItEasy
{
	public struct HexagonView
	{
		public float Edge { get; set; }
		public PointF Center { get; set; }
		public Color BorderColor { get; set; }
		public Color Color { get; set; }
		public float BorderThickness { get; set; } // ratio border to edge

		public HexagonView(float edge, PointF center)
		{
			Edge = edge;
			Center = center;
			BorderColor = Color.LightPink;
			Color = Color.DeepPink;
			BorderThickness = 0.05f;
		}
	}
}