﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace BoxIt.Content
{
	internal sealed class TileMap
	{
		public TileMap(TileMapRaw raw, IList<TileType> tileTypes, IList<WallType> wallTypes)
		{
			// Transform our input data a bit
			var rawTiles = raw.Tiles.Split(new[] {' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries);
			var rawWalls = raw.Walls.Split(new[] {' ', '\n', '\t'}, StringSplitOptions.RemoveEmptyEntries);
			var height = rawTiles.Length/raw.Width;

			// Initialize our map in advance
			Tiles = new Tile[raw.Width][];
			for (var x = 0; x < raw.Width; x++)
				Tiles[x] = new Tile[height];

			// Parse in the map
			for (var y = 0; y < height; y++)
			{
				for (var x = 0; x < raw.Width; x++)
				{
					var tile = int.Parse(rawTiles[(y*raw.Width) + x]);
					var wall = int.Parse(rawWalls[(y*raw.Width) + x]);

					if (tile != -1)
						Tiles[x][y].Type = tileTypes[tile];
					if (wall != -1)
						Tiles[x][y].Wall = wallTypes[wall];
				}
			}
		}

		public Tile[][] Tiles { get; set; }
		public Texture2D Tileset { get; set; }
	}
}