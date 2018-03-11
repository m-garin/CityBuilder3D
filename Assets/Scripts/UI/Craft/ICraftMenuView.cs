
namespace UI.Craft
{
    public interface ICraftMenuView : IWindowView
    {
        ICraftMenuController Controller { set; }
        bool MenuIsOpen();
    }
}