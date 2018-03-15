using System.Collections.Generic;
using Buildings;
using Buildings.Real;
using PlacementArea.Tiles;
using Settings;
using UnityEngine;

namespace PlacementArea
{
    public class BuildingPlacementArea : MonoBehaviour, IPlacementArea
    {
        [SerializeField]
        MapSettings mapSettings;
        [SerializeField]
        BoxCollider planeCollider;
        [SerializeField]
        RealFactory buildingFactory;
        [SerializeField]
        TileFactory tileFactory;

        List<IBuilding> buildings; //already constructed buildings
        ITile[,] tiles;
        IHighlightTiles highlightTiles;

        void Start()
        {
            buildings = new List<IBuilding>();
            //generate area
            tiles = new CreatePlacementArea().Generate(tileFactory, planeCollider, mapSettings.MapWidth, mapSettings.MapHight);
            //set tiles checker
            highlightTiles = new HighlightTiles(this);
        }

        /// <summary>
        /// Get placement area tile
        /// </summary>
        public ITile GetTile(Vector2Int _gridPos)
        {
            //check the boundaries
            if (_gridPos.x < 0 || _gridPos.y < 0 || _gridPos.x > mapSettings.MapWidth || _gridPos.y > mapSettings.MapHight)
            {
                Debug.LogError("Out of bounds");
                return null;
            }

            return tiles[_gridPos.x, _gridPos.y];
        }

        /// <summary>
        /// Try to place building
        /// </summary>
        public FitStatus Fits(Vector2Int _gridPos, IBuilding _building)
        {
            Vector2Int extents = new Vector2Int(_gridPos.x + _building.Width, _gridPos.y + _building.Height);

            if (_gridPos.x < 0 || _gridPos.y < 0 || extents.x > mapSettings.MapWidth || extents.y > mapSettings.MapHight)
            {
                return FitStatus.OutOfBounds;
            }
            highlightTiles.HighlightTile(_gridPos, _building);

            for (int y = _gridPos.y; y < extents.y; y++)
            {
                for (int x = _gridPos.x; x < extents.x; x++)
                {
                    if (!tiles[x, y].Empty)
                    {
                        return FitStatus.Overlaps;
                    }
                }
            }

            return FitStatus.Fits;
        }

        /// <summary>
        /// Build a building
        /// </summary>
        public void PlaceBuilding(Vector2Int _gridPos, BuildingType _buildingType)
        {
            //buildings
            IBuilding building = buildingFactory.Create(_buildingType, _gridPos, -0.6f);
            buildings.Add(building);
            highlightTiles.Reset();

            Vector2Int extents = new Vector2Int(_gridPos.x + building.Width, _gridPos.y + building.Height);

            for (int y = _gridPos.y; y < extents.y; y++)
            {
                for (int x = _gridPos.x; x < extents.x; x++)
                {
                    tiles[x, y].Empty = false;
                }
            }
        }

        /// <summary>
        /// Destroy the building
        /// </summary>
        public void DestroyBuilding(IBuilding _building)
        {
            Vector2Int gridPos = _building.Position;
            Vector2Int extents = new Vector2Int(gridPos.x + _building.Width, gridPos.y + _building.Height);

            for (int y = gridPos.y; y < extents.y; y++)
            {
                for (int x = gridPos.x; x < extents.x; x++)
                {
                    tiles[x, y].Empty = true;
                }
            }
            buildings.Remove(_building);
            _building.Destroy();
        }
    }
}