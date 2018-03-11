using Buildings;
using PlacementArea.Tiles;
using UnityEngine;

namespace PlacementArea
{
    public interface IPlacementArea
    {
        FitStatus Fits(Vector2Int _gridPos, IBuilding _building);
        ITile GetTile(Vector2Int _gridPos);
        void DestroyBuilding(IBuilding _building);
    }
}