using Buildings;
using UnityEngine;

namespace PlacementArea
{
    public interface IHighlightTiles
    {
        void HighlightTile(Vector2Int _gridPos, IBuilding _building);
        void Reset();
    }
}