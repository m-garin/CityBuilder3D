using UnityEngine;
using UnityEngine.UI;

namespace UI.BuildingManager
{
    public class PopUpView : AbstractWindowView, IPopUpView
    {
        [SerializeField]
        Button infoBtn;
        [SerializeField]
        Button deleteBtn;

        IPopUpController controller;

        void Start()
        {
            infoBtn.onClick.AddListener(controller.ShowInfo);
            deleteBtn.onClick.AddListener(controller.DeleteObject);
        }

        public override void OnOutsideClick()
        {
            controller.HideMenu();
        }

        public IPopUpController Controller
        {
            set
            {
                controller = value;
            }
        }
    }
}