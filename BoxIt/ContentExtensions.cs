﻿using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace BoxIt
{
	internal static class ContentExtensions
	{
		public static TileMap LoadMap(this ContentManager content, string assetName, IList<TileType> typeLookupTable)
		{
			return new TileMap(content.Load<TileMapRaw>(assetName), typeLookupTable);
		}
	}
}