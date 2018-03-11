using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(menuName = "MapSettings")]
    public class MapSettings : ScriptableObject
    {

        [SerializeField]
        int mapHight = 100;
        public int MapHight
        {
            get
            {
                return mapHight;
            }
        }

        [SerializeField]
        int mapWidth = 100;
        public int MapWidth
        {
            get
            {
                return mapWidth;
            }
        }

        [SerializeField]
        /// <summary>
        /// GameObject for tile
        /// </summary>
        GameObject tilePrefab;
        public GameObject TilePrefab
        {
            get
            {
                return tilePrefab;
            }
        }
    }
}