using Buildings;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Craft
{
    public class CraftMenuView : AbstractWindowView, ICraftMenuView
    {

        [SerializeField]
        Button craftButton;
        [SerializeField]
        Button building1x1Button;
        [SerializeField]
        Button building2x2Button;
        [SerializeField]
        Button building3x3Button;

        ICraftMenuController controller;

        public ICraftMenuController Controller
        {
            set
            {
                controller = value;
            }
        }

        void Start()
        {
            //Handling UI events
            craftButton.onClick.AddListener(() => controller.ClickMenu());
            building1x1Button.onClick.AddListener(() => controller.StartCraft(BuildingType.Building1x1));
            building2x2Button.onClick.AddListener(() => controller.StartCraft(BuildingType.Building2x2));
            building3x3Button.onClick.AddListener(() => controller.StartCraft(BuildingType.Building3x3));
        }

        public bool MenuIsOpen()
        {
            return this.gameObject.activeSelf;
        }
    }
}