using System.Collections.Generic;
using Buildings;
using PlacementArea.Tiles;
using UnityEngine;

namespace PlacementArea
{
    public class HighlightTiles : IHighlightTiles
    {
        List<ITile> highlightedTiles;
        IPlacementArea placementArea;

        public HighlightTiles(IPlacementArea _placementArea)
        {
            placementArea = _placementArea;
            highlightedTiles = new List<ITile>();
        }

        public void HighlightTile(Vector2Int _gridPos, IBuilding _building)
        {
            Reset();
            Vector2Int extents = new Vector2Int(_gridPos.x + _building.Width, _gridPos.y + _building.Height);

            for (int y = _gridPos.y; y < extents.y; y++)
            {
                for (int x = _gridPos.x; x < extents.x; x++)
                {
                    ITile tile = placementArea.GetTile(new Vector2Int(x, y));
                    tile.Glow(true);
                    highlightedTiles.Add(tile);
                }
            }
        }

        public void Reset()
        {
            for (int i = highlightedTiles.Count - 1; i >= 0; i--)
            {
                highlightedTiles[i].Glow(false);
                highlightedTiles.RemoveAt(i);
            }
        }
    }
}