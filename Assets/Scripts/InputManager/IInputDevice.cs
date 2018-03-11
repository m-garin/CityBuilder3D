using System;
using Buildings;
using UnityEngine;

namespace InputManager
{
    public interface IInputDevice
    {
        Vector2Int Position { get; }

        event Action<Vector2Int> CursorPosition;
        event Action LBMPressed;
        IBuilding Selected { get; }
    }
}