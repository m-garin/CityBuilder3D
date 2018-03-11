using UnityEngine;
using System.Collections.Generic;

namespace Buildings.Ghost
{
    public class GhostFactory : MonoBehaviour, IBuildingFactory
    {
        [SerializeField]
        List<GameObject> buildingPrefabs;
        [SerializeField]
        Transform parentLayer;

        /// <summary>
        /// Create a ghost building
        /// </summary>
        public IBuilding Create(BuildingType _type, Vector2Int _position, float elevateZ = 0.0f)
        {
            GameObject go = Instantiate(buildingPrefabs[(int)_type], new Vector3(_position.x, _position.y, elevateZ), Quaternion.identity, parentLayer);
            return go.GetComponent<Building>();
        }
    }
}