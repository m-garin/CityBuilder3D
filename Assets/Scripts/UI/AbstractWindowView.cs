using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public abstract class AbstractWindowView : MonoBehaviour
    {
        GameObject overlayWindow;

        protected void SetSelected(GameObject _go)
        {
            EventSystem.current.SetSelectedGameObject(_go);
        }

        /// <summary>
        /// Create overlay window
        /// </summary>
        void SetupInvisibleWndBG()
        {
            overlayWindow = new GameObject("OverlayWindow");

            OverlayWindow tempOverlayWindow = overlayWindow.AddComponent<OverlayWindow>();
            tempOverlayWindow.SetParentCtrl(this);

            Image tempImage = overlayWindow.AddComponent<Image>();
            tempImage.color = new Color(1f, 1f, 1f, 0f);

            RectTransform tempTransform = overlayWindow.GetComponent<RectTransform>();
            tempTransform.anchorMin = new Vector2(0f, 0f);
            tempTransform.anchorMax = new Vector2(1f, 1f);
            tempTransform.offsetMin = new Vector2(0f, 0f);
            tempTransform.offsetMax = new Vector2(0f, 0f);
            tempTransform.SetParent(GetComponentsInParent<Transform>()[1], false);
            tempTransform.SetSiblingIndex(transform.GetSiblingIndex()); // put it right beind this panel in the hierarchy
        }

        public void Hide()
        {
            this.gameObject.SetActive(false);
            Destroy(overlayWindow);
        }

        public void Show()
        {
            this.gameObject.SetActive(true);
            if (overlayWindow == null)
            {
                SetupInvisibleWndBG();
            }
            overlayWindow.SetActive(true);
            SetSelected(this.gameObject);
        }
    }
}