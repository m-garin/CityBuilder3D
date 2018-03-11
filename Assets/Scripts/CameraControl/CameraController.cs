using CameraControl.InputType;
using UnityEngine;

namespace CameraControl
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField]
        int minFieldOfView = 4;
        [SerializeField]
        int maxFieldOfView = 30;
        [SerializeField]
        float dragSpeed = 1.0f;

        ICameraControl cameraControl;

        void Awake()
        {
            cameraControl = new PCCameraControl(dragSpeed);
        }

        float FieldOfView
        {
            get
            {
                return Camera.main.fieldOfView;
            }
            set
            {
                Camera.main.fieldOfView = Mathf.Clamp(value, minFieldOfView, maxFieldOfView);
            }
        }

        void LateUpdate()
        {
            FieldOfView = cameraControl.Zoom(FieldOfView); //Zoom
            transform.Translate(cameraControl.Move(), Space.World); //Move
        }
    }
}