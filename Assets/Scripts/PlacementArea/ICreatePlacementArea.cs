using PlacementArea.Tiles;
using UnityEngine;

namespace PlacementArea
{
    public interface ICreatePlacementArea
    {
        ITile[,] Generate(ITileFactory _tileGenerator, BoxCollider _planeCollider, int _width, int _height);
    }
}