using PlacementArea.Tiles;
using UnityEngine;

namespace PlacementArea
{
    public class CreatePlacementArea : ICreatePlacementArea
    {
        ITile[,] tiles;
        int width;
        int height;

        public ITile[,] Generate(ITileFactory _tileGenerator, BoxCollider _planeCollider, int _width = 100, int _height = 100)
        {
            width = _width;
            height = _height;

            tiles = new ITile[width, height];
            _planeCollider.transform.position += new Vector3(width / 2, height / 2, 0);
            _planeCollider.size = new Vector3(width, height, _planeCollider.size.z);

            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    tiles[x, y] = _tileGenerator.Create(x, y);
                }
            }

            FillRandomTiles(10);

            return tiles;
        }

        void FillRandomTiles(int _chance)
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (Random.Range(0, 99) < _chance)
                        tiles[x, y].Empty = false;
                }
            }
        }
    }
}