using UnityEngine;

namespace CameraControl.InputType
{
    public class PCCameraControl : ICameraControl
    {
        Vector2 dragOrigin;
        float dragSpeed = 2.0f;

        public PCCameraControl(float _dragSpeed)
        {
            dragSpeed = _dragSpeed;
        }

        /// <summary>
        /// Zoom in/out camera with mouse scroll wheel
        /// </summary>
        public float Zoom(float _fieldOfView)
        {
            // zoom out
            if (Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                _fieldOfView += 1;
            }
            else if (Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                _fieldOfView -= 1;
            }

            return _fieldOfView;
        }

        /// <summary>
        /// Move camera with mouse
        /// </summary>
        public Vector2 Move()
        {
            Vector2 move = Vector2.zero;
            if (Input.GetMouseButtonDown(1))
            {
                dragOrigin = Input.mousePosition;
                return move;
            }

            if (!Input.GetMouseButton(1)) return move;

            Vector3 delta = new Vector3(dragOrigin.x, dragOrigin.y, 0.0f) - Input.mousePosition;
            move = Camera.main.ScreenToViewportPoint(delta) * dragSpeed;
            return move;
        }
    }
}