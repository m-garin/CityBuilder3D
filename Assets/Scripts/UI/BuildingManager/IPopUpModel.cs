using Buildings;

namespace UI.BuildingManager
{
    public interface IPopUpModel
    {
        IBuilding SetBuilding { set; }
        int GetWidth();
        int GetHeight();
        void DeleteObject();
    }
}