using System;
using Buildings;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InputManager
{
    public class MouseInput : MonoBehaviour, IInputDevice
    {
        Vector2Int lastPosition = Vector2Int.zero;
        public IBuilding Selected { get; private set; }

        /// <summary>
        /// Get input position
        /// </summary>
        public Vector2Int Position
        {
            get
            {
                return lastPosition;
            }
        }

        public event Action<Vector2Int> CursorPosition;
        /// <summary>
        /// Left button mouse pressed event
        /// </summary>
        public event Action LBMPressed;
        bool LBMPressedFlag;

        void Update()
        {
            LBMPressedFlag = Input.GetMouseButtonDown(0) && !IsUIObject();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray, 100.0f);

            for (int i = 0; i < hits.Length; i++)
            {
                if (i == 0)
                    CursorPosition?.Invoke(GetPosition(hits[i]));

                Selected = SelectObject(hits[i]);
            }

            if (LBMPressedFlag)
                LBMPressed?.Invoke();
        }

        IBuilding SelectObject(RaycastHit _hit)
        {
            return _hit.transform.GetComponent<Building>();
        }

        Vector2Int GetPosition(RaycastHit _hit)
        {
            return new Vector2Int(Mathf.FloorToInt(_hit.point.x + 0.5f), Mathf.FloorToInt(_hit.point.y + 0.5f)); //round
        }

        /// <summary>
        /// If pointer is over UI object
        /// </summary>
        bool IsUIObject()
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}