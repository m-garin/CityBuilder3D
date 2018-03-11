using UnityEngine;

namespace Buildings
{
    public interface IBuildingFactory
    {
        IBuilding Create(BuildingType _type, Vector2Int _position, float elevateZ);
    }
}