using System;
using System.Collections.Generic;

namespace TakeItEasy.Model
{
	public class Game
	{
		private readonly List<Tile> availableTiles;
		private readonly Dictionary<int, Tile> tiles;
		private readonly Random random;

		public Game()
		{
			availableTiles = GetAvailableTiles();
			tiles = new Dictionary<int, Tile>();
			random = new Random();
		}

		public IEnumerable<KeyValuePair<int, Tile>> GetTiles()
		{
			return tiles;
		}

		public void AddTileOnField(int position, Tile tile)
		{
			tiles.Add(position, tile);
		}

		public Tile GetNextTile()
		{
			var randomIndex = random.Next(0, availableTiles.Count - 1);

			var nextTile = availableTiles[randomIndex];
			availableTiles.RemoveAt(randomIndex);

			return nextTile;
		}

		private static List<Tile> GetAvailableTiles()
		{
			var availableTiles = new List<Tile>();

			var leftNumbers = new[] { 2, 6, 7 };
			var topNumbers = new[] { 1, 5, 9 };
			var rightNumbers = new[] { 3, 4, 8 };

			foreach (var rn in rightNumbers)
			foreach (var tn in topNumbers)
			foreach (var ln in leftNumbers)
				availableTiles.Add(new Tile(tn, rn, ln));

			return availableTiles;
		}
	}
}
