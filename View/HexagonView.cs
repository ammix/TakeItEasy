using System;
using System.Drawing;

namespace TakeItEasy.View
{
	public struct HexagonView
	{
		private static readonly float sqrt3 = (float) Math.Sqrt(3);
		private float edge;
		private PointF center;

		public float Edge
		{
			get { return edge; }
			set { edge = value; }
		}

		public PointF Center
		{
			get { return center; }
			set { center = value; }
		}

		public Color BorderColor { get; set; }
		public Color Color { get; set; }
		public float BorderThickness { get; set; } // ratio border to edge

		public HexagonView(float edge, PointF center)
		{
			this.edge = edge;
			this.center = center;

			BorderColor = Color.Black;
			Color = Color.White;
			BorderThickness = 0.01f;
		}

		public HexagonView(HexagonView hxView) : this(hxView.Edge, hxView.Center)
		{ }
	}
}