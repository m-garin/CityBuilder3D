using UnityEngine;

namespace PlacementArea.Tiles
{
    public interface ITile
    {
        GameObject SetPrefab { set; }

        bool Empty { get; set; }

        void Glow(bool _turn);
    }
}