using System;
using System.Collections.Generic;
using TakeItEasy.Model;

namespace TakeItEasy
{
	public class Game
	{
		private readonly List<Tile> availableTiles = new List<Tile>();
		private int index = 0;

		public Tile?[] Tiles;

		public Game()
		{
			Tiles = new Tile?[19];

			var leftNumbers = new[] {2, 6, 7};
			var topNumbers = new[] {1, 5, 9};
			var rightNumbers = new[] {3, 4, 8};

			foreach (var rn in rightNumbers)
			{
				foreach (var tn in topNumbers)
				{
					foreach (var ln in leftNumbers)
					{
						availableTiles.Add(new Tile(tn, rn, ln));
					}
				}
			}
		}

		public Tile GetNextTile()
		{
			//var r = new Random();
			//var tileIndex = r.Next(1, 27);

			//tiles[0] = availableTiles[tileIndex];		
			Tiles[index] = new Tile(9, 8, 7);
			//Tiles[index] = availableTiles[index];

			//index++;

			return new Tile(9, 8, 7);
		}
	}
}
