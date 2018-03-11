using Buildings;

namespace UI.Craft
{
    public interface ICraftMenuController
    {

        void StartCraft(BuildingType _buildingType);
        void ClickMenu();
    }
}