using System.Drawing;
using TakeItEasy.Model;

namespace TakeItEasy
{
	public struct TileHexagonView
	{
		public HexagonView HexagonView;
		public float BarThickness { get; }
		public TileModel TileModel;

		private const float barThickness = 0.25f; // 15/62

		//public Tuple<int, Color> GetBar1()

		//public Color => {
		//	return GetBarColor();
		//}
		//public Color Color
		//{
		//	get { return GetBarColor()}
		//}

		public TileHexagonView(HexagonView hexagonView, TileModel tileModel)
		{
			HexagonView = hexagonView;
			BarThickness = barThickness * hexagonView.Edge;
			TileModel = tileModel;
		}

		public Color TopBarColor => GetBarColor(TileModel.Top);
		public Color LeftBarColor => GetBarColor(TileModel.Left);
		public Color RightBarColor => GetBarColor(TileModel.Right);

		private Color GetBarColor(int number)
		{
			switch (number)
			{
				case 1: return Color.Black;
				case 2: return Color.Silver;
				case 3: return Color.Pink;
				case 4: return Color.DeepSkyBlue;
				case 5: return Color.Gray;
				case 6: return Color.Red;
				case 7: return Color.LimeGreen; // LawnGreen;
				case 8: return Color.Orange;
				case 9: return Color.Yellow;
				default: return Color.White;
			}
		}
	}
}
