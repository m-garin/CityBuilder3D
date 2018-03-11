using UnityEngine;
using System.Collections.Generic;
using Buildings;

namespace Buildings.Real
{
    public class RealFactory : MonoBehaviour, IBuildingFactory
    {
        [SerializeField]
        List<GameObject> buildingPrefabs;
        [SerializeField]
        Transform parentLayer;

        /// <summary>
        /// Create a real building
        /// </summary>
        public IBuilding Create(BuildingType _type, Vector2Int _position, float elevateZ = 0.0f)
        {
            GameObject go = Instantiate(buildingPrefabs[(int)_type], new Vector3(_position.x, _position.y, elevateZ), Quaternion.identity, parentLayer);
            return go.GetComponent<Building>();
        }
    }
}