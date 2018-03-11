using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class OverlayWindow : MonoBehaviour, IPointerClickHandler
    {
        AbstractWindowView parentCtrl;

        public void SetParentCtrl(AbstractWindowView _ctrl)
        {
            parentCtrl = _ctrl;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            parentCtrl.OnOutsideClick();
        }
    }
}