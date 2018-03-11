using Buildings;
using InputManager;

namespace UI.Craft
{
    public class CraftModel : ICraftModel
    {
        readonly IGhostInputManager ghostManager;

        public CraftModel(IGhostInputManager _ghostManager)
        {
            ghostManager = _ghostManager;
        }

        /// <summary>
        /// Start new building placement
        /// </summary>
        public void StartCraft(BuildingType _buildingType)
        {
            ghostManager.CancelPlacement();
            ghostManager.StartPlacement(_buildingType);
        }
    }
}