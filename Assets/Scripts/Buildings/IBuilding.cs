using UnityEngine;

namespace Buildings
{
    public interface IBuilding
    {
        int Width { get; }
        int Height { get; }
        BuildingType Type { get; }
        Vector2Int Position { get; }
        void MovePrefab(Vector2Int _position);
        void Destroy();
    }
}