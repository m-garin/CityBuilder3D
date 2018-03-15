using Buildings;
using Buildings.Ghost;
using PlacementArea;
using UI.BuildingsManager;
using UnityEngine;

namespace InputManager
{
    public class GhostInputManager : MonoBehaviour, IGhostInputManager
    {
        [SerializeField]
        BuildingPlacementArea placementArea;
        [SerializeField]
        GhostFactory buildingFactory;
        [SerializeField]
        MouseInput input;
        [SerializeField]
        UIBuildingsManager buildingsManager;

        IBuilding buildingGhost;
        float elevateZ = -1.2f; //Height above ground level
        bool isBuilding = false;
        public bool IsBuilding 
        { 
            get
            {
                return isBuilding;
            }
            private set
            {
                isBuilding = value;
            }
        }

        /// <summary>
        /// Start new building placement
        /// </summary>
        public void StartPlacement(BuildingType _buildingType)
        {
            buildingGhost = buildingFactory.Create(_buildingType, input.Position, elevateZ);
            IsBuilding = true;
            buildingsManager.Disable();
            input.CursorPosition += Move;
            input.LBMPressed += TryPlace;
        }

        void Move(Vector2Int _position)
        {
            if (IsBuilding)
            {
                buildingGhost.MovePrefab(_position);
                CheckFits();
            }
        }

        FitStatus CheckFits()
        {
            return placementArea.Fits(buildingGhost.Position, buildingGhost);
        }

        /// <summary>
        /// Cancel new building placement
        /// </summary>
        public void CancelPlacement()
        {
            if (IsBuilding)
            {
                IsBuilding = false;
                input.CursorPosition -= Move;
                input.LBMPressed -= TryPlace;
                buildingGhost.Destroy();
                buildingsManager.Enable();
            }
        }

        void TryPlace()
        {
            if (IsBuilding && CheckFits() == FitStatus.Fits)
            {
                PlaceGhost();
            }
        }

        void PlaceGhost()
        {
            placementArea.PlaceBuilding(buildingGhost.Position, buildingGhost.Type);
            CancelPlacement();
        }
    }
}