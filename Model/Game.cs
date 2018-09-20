using System;
using System.Collections.Generic;

namespace TakeItEasy.Model
{
	public class Game
	{
		private List<Tile> availableTiles;
		private readonly Dictionary<int, Tile> tiles;
		private readonly Random random;

		public Game()
		{
			tiles = new Dictionary<int, Tile>();
			random = new Random();
		}

		public void StartNew()
		{
			tiles.Clear();
			availableTiles = GetAvailableTiles();
		}

		public Tile NewTile { get; private set; }

		public IEnumerable<KeyValuePair<int, Tile>> GetTiles()
		{
			return tiles;
		}

		public bool AddTileOnField(int position, Tile tile)
		{
			if (tiles.ContainsKey(position))
				return false;

			tiles.Add(position, tile);
			return true;
		}

		public void AddNewTile()
		{
			NewTile = GetNextTile();
		}

		public void ChangeTilePosition(int prevIndex, int newIndex)
		{
			if (!tiles.ContainsKey(prevIndex))
				return;

			if (tiles.ContainsKey(newIndex))
				return;

			var tile = tiles[prevIndex];
			tiles.Add(newIndex, tile);
			tiles.Remove(prevIndex);
		}

		public Tile? GetTile(int index)
		{
			if (tiles.ContainsKey(index))
				return tiles[index];

			return null;
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
