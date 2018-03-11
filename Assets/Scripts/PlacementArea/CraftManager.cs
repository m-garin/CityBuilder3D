using InputManager;
using UI.Craft;
using UnityEngine;

namespace PlacementArea
{
    /// <summary>
    /// CraftManager class
    /// Craft UI management
    /// </summary>
    public class CraftManager : MonoBehaviour
    {
        [SerializeField]
        CraftMenuView view;
        [SerializeField]
        GhostInputManager ghostManager;

        ICraftModel model;
        ICraftMenuController controller;

        void Start()
        {
            model = new CraftModel(ghostManager);
            controller = new CraftMenuController(view, model);
        }
    }
}