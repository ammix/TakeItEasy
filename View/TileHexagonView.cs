using System.Drawing;
using TakeItEasy.Model;
using TakeItEasy.View;

namespace TakeItEasy
{
	public struct TileHexagonView
	{
		public HexagonView HexagonView;
		public float BarThickness { get; }
		public Tile Tile;

		private const float barThickness = 0.25f; // 15/62

		//public Tuple<int, Color> GetBar1()

		//public Color => {
		//	return GetBarColor();
		//}
		//public Color Color
		//{
		//	get { return GetBarColor()}
		//}

		public TileHexagonView(HexagonView hexagonView, Tile tile)
		{
			HexagonView = hexagonView;
			BarThickness = barThickness * hexagonView.Edge;
			Tile = tile;
		}

		public Color TopBarColor => GetBarColor(Tile.TopNumber);
		public Color LeftBarColor => GetBarColor(Tile.LeftNumber);
		public Color RightBarColor => GetBarColor(Tile.RightNumber);

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
