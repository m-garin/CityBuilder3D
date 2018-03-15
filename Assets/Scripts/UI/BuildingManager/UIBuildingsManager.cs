using Buildings;
using InputManager;
using PlacementArea;
using PlacementArea.BuildingsManager;
using UI.BuildingManager;
using UnityEngine;

namespace UI.BuildingsManager
{
    /// <summary>
    /// BuildingsManager class
    /// Open windows for building management
    /// </summary>
    public class UIBuildingsManager : MonoBehaviour, IUIBuildingsManager
    {
        [SerializeField]
        MouseInput input;
        [SerializeField]
        PopUpView menuView;
        [SerializeField]
        InformationPanelView infoView;
        [SerializeField]
        BuildingPlacementArea placementArea;

        IPopUpModel model;
        IPopUpController controller;

        void Start()
        {
            model = new PopUpModel(placementArea);
            controller = new PopUpController(model, menuView, infoView);
        }

        void OnEnable()
        {
            input.LBMPressed += OpenPopUp;
        }

        void OnDestroy()
        {
            input.LBMPressed -= OpenPopUp;
        }

        void OpenPopUp()
        {
            if (this.gameObject.activeSelf)
            {
                IBuilding building = input.Selected;
                if (building != null) //if building is selected
                {
                    model.SetBuilding = building; //set new building for model
                    controller.ShowMenu(); //show main building menu
                }
            }
        }

        public void Enable()
        {
            this.gameObject.SetActive(true);
        }

        public void Disable()
        {
            this.gameObject.SetActive(false);
        }
    }
}