
namespace UI.BuildingManager
{
    public class PopUpController : IPopUpController
    {
        readonly IPopUpModel model;
        readonly IPopUpView menuView;
        readonly IInformationPanelView infoView;

        public PopUpController(IPopUpModel _model, IPopUpView _menuView, IInformationPanelView _infoView)
        {
            model = _model;
            infoView = _infoView;
            menuView = _menuView;
            menuView.Controller = this;
        }

        /// <summary>
        /// Show menu with action choice
        /// </summary>
        public void ShowMenu()
        {
            menuView.Show();
        }

        /// <summary>
        /// Hide menu with action choice
        /// </summary>
        public void HideMenu()
        {
            menuView.Hide();
            HideInfo();
        }

        /// <summary>
        /// Show window with information about the constuction
        /// </summary>
        public void ShowInfo()
        {
            menuView.Hide();
            infoView.Constructor(model, this);
            infoView.Show();
            infoView.UpdateView();
        }

        /// <summary>
        /// Hide window with information about the constuction
        /// </summary>
        public void HideInfo()
        {
            infoView.Hide();
        }

        public void DeleteObject()
        {
            model.DeleteObject();
            HideMenu();
        }
    }
}