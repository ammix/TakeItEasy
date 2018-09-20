using System.Drawing;

namespace TakeItEasy.View
{
	public struct HexagonStyle
	{
		public Color Color { get; set; }
		public Color BorderColor { get; set; }
		public float BorderThickness { get; set; } // ratio border to edge		

		//public HexagonStyle()
		//{ }

		public HexagonStyle(Color color, Color borderColor, float borderThickness)
		{
			Color = color;
			BorderColor = borderColor;
			BorderThickness = borderThickness;
		}
	}
}
