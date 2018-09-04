namespace TakeItEasy.Model
{
	public struct Tile
	{
		public int TopNumber;
		public int RightNumber;
		public int LeftNumber;

		public Tile(int top, int right, int left)
		{
			TopNumber = top;
			RightNumber = right;
			LeftNumber = left;
		}
	}
}
