using UnityEngine;

namespace PlacementArea.Tiles
{
    public class TileObject : ITile
    {
        GameObject prefab;
        readonly Color emptyColor = Color.green;
        readonly Color occupiedColor = Color.red;
        Color baseColor;

        public TileObject()
        {
            Empty = true;
        }

        public GameObject SetPrefab
        {
            set
            {
                prefab = value;
                baseColor = PrefabColor;
            }
        }

        Color PrefabColor
        {
            get
            {
                return prefab.GetComponent<Renderer>().material.color;
            }
            set
            {
                prefab.GetComponent<Renderer>().material.color = value;
            }
        }

        public bool Empty { get; set; }

        /// <summary>
        /// Highlight selected tile
        /// </summary>
        public void Glow(bool _turn)
        {
            if (prefab != null)
            {
                if (_turn)
                {
                    if (Empty)
                    {
                        PrefabColor = emptyColor;
                    }
                    else
                    {
                        PrefabColor = occupiedColor;
                    }
                }
                else
                {
                    PrefabColor = baseColor;
                }
            }
        }
    }
}