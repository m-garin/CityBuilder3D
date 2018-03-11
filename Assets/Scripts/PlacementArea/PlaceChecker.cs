using System.Collections.Generic;
using Buildings;
using PlacementArea.Tiles;
using UnityEngine;

namespace PlacementArea
{
    public class PlaceChecker : IPlaceChecker
    {
        List<ITile> checkedTiles;
        IPlacementArea placementArea;

        public PlaceChecker(IPlacementArea _placementArea)
        {
            placementArea = _placementArea;
            checkedTiles = new List<ITile>();
        }

        public void Check(Vector2Int _gridPos, IBuilding _building)
        {
            Reset();
            Vector2Int extents = new Vector2Int(_gridPos.x + _building.Width, _gridPos.y + _building.Height);

            for (int y = _gridPos.y; y < extents.y; y++)
            {
                for (int x = _gridPos.x; x < extents.x; x++)
                {
                    ITile tile = placementArea.GetTile(new Vector2Int(x, y));
                    tile.Glow(true);
                    checkedTiles.Add(tile);
                }
            }
        }

        public void Reset()
        {
            for (int i = checkedTiles.Count - 1; i >= 0; i--)
            {
                checkedTiles[i].Glow(false);
                checkedTiles.RemoveAt(i);
            }
        }
    }
}