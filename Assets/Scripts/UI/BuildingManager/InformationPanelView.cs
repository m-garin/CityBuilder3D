using UnityEngine;
using UnityEngine.UI;

namespace UI.BuildingManager
{
    public class InformationPanelView : AbstractWindowView, IInformationPanelView
    {
        [SerializeField]
        Text widthTextLine;
        [SerializeField]
        Text heightTextLine;

        IPopUpModel model;
        IPopUpController controller;

        public void Constructor(IPopUpModel _model, IPopUpController _controller)
        {
            model = _model;
            controller = _controller;
        }

        public void UpdateView()
        {
            widthTextLine.text = "Ширина: " + model.GetWidth();
            heightTextLine.text = "Высота: " + model.GetHeight();
        }

        public override void OnOutsideClick()
        {
            controller.HideMenu();
        }
    }
}