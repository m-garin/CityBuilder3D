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

        public void Constructor(IPopUpModel _model)
        {
            model = _model;
        }

        public void UpdateView()
        {
            widthTextLine.text = "Ширина: " + model.GetWidth();
            heightTextLine.text = "Высота: " + model.GetHeight();
        }
    }
}