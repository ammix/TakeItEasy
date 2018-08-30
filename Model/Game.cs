using System;
using System.Collections.Generic;
using TakeItEasy.Model;

namespace TakeItEasy
{
	public class Game
	{
		private readonly List<TileModel> availableTiles = new List<TileModel>();
		private int index = 0;

		public TileModel?[] Tiles;

		public Game()
		{
			Tiles = new TileModel?[19];

			var leftNumbers = new[] {2, 6, 7};
			var topNumbers = new[] {1, 5, 9};
			var rightNumbers = new[] {3, 4, 8};

			foreach (var rn in rightNumbers)
			{
				foreach (var tn in topNumbers)
				{
					foreach (var ln in leftNumbers)
					{
						availableTiles.Add(new TileModel(tn, rn, ln));
					}
				}
			}
		}

		public void GetNextTile()
		{
			//var r = new Random();
			//var tileIndex = r.Next(1, 27);

			//tiles[0] = availableTiles[tileIndex];		
			Tiles[index] = new TileModel(9, 8, 7);

			index++;
		}
	}
}
