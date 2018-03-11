namespace UI.BuildingManager
{
    public interface IInformationPanelView : IWindowView
    {
        void UpdateView();
        void Constructor(IPopUpModel _model);
    }
}