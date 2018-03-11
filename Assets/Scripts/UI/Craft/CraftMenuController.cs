using Buildings;

namespace UI.Craft
{
    public class CraftMenuController : ICraftMenuController
    {
        readonly ICraftMenuView view;
        readonly ICraftModel model;

        public CraftMenuController(ICraftMenuView _view, ICraftModel _model)
        {
            view = _view;
            view.Controller = this;
            model = _model;
            view.Hide();
        }

        /// <summary>
        /// Start new building placement
        /// </summary>
        public void StartCraft(BuildingType _buildingType)
        {
            model.StartCraft(_buildingType);
            view.Hide();
        }

        public void ClickMenu()
        {
            if (view.MenuIsOpen())
                view.Hide();
            else
                view.Show();
        }
    }
}