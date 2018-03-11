using UnityEngine;

namespace PlacementArea.Tiles
{
    public class TileFactory : MonoBehaviour, ITileFactory
    {
        [SerializeField]
        GameObject tilePrefab;
        [SerializeField]
        Transform parentLayer;

        /// <summary>
        /// Create a new placement area tile
        /// </summary>
        public ITile Create(int _x, int _y)
        {
            ITile tile = new TileObject
            {
                SetPrefab = Instantiate(tilePrefab, new Vector3(_x, _y, tilePrefab.transform.position.z / 2.0f), Quaternion.identity, parentLayer)
            };

            return tile;
        }
    }
}