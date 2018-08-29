namespace TakeItEasy.Model
{
	public struct TileModel
	{
		public TileModel(int top, int right, int left)
		{
			Top = top;
			Right = right;
			Left = left;
		}

		public int Top;
		public int Right;
		public int Left;
	}
}
