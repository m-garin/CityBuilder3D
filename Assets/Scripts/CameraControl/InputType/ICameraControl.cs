using UnityEngine;

namespace CameraControl.InputType
{
    public interface ICameraControl
    {
        float Zoom(float _fieldOfView);
        Vector2 Move();
    }
}