using Buildings;

namespace InputManager
{
    public interface IGhostInputManager
    {
        void StartPlacement(BuildingType _buildingType);
        void CancelPlacement();
        bool IsBuilding { get; }
    }
}