using Buildings;
using UnityEngine;

namespace PlacementArea
{
    public interface IPlaceChecker
    {
        void Check(Vector2Int _gridPos, IBuilding _building);
        void Reset();
    }
}