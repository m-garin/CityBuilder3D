
namespace UI.BuildingManager
{
    public interface IPopUpView : IWindowView
    {
        IPopUpController Controller { set; }
    }
}