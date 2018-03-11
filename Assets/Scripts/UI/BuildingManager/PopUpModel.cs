
using Buildings;
using PlacementArea;

namespace UI.BuildingManager
{
    /// <summary>
    /// PopUpModel class
    /// </summary>
    public class PopUpModel : IPopUpModel
    {
        IBuilding building;
        readonly IPlacementArea placemanetArea;

        public PopUpModel(IPlacementArea _placemanetArea)
        {
            placemanetArea = _placemanetArea;
        }

        public IBuilding SetBuilding
        {
            set
            {
                building = value;
            }
        }

        public int GetWidth()
        {
            return building.Width;
        }

        public int GetHeight()
        {
            return building.Height;
        }

        public void DeleteObject()
        {
            placemanetArea.DestroyBuilding(building);
        }
    }
}