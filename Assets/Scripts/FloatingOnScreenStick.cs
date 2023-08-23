using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.OnScreen;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

[AddComponentMenu("Input/Floating On-Screen Stick")]
public class FloatingOnScreenStick : OnScreenStick
{
    public void OnPointerDown(PointerEventData eventData)
    {
        OnScreenStick baseInstance = new OnScreenStick();
        baseInstance.OnPointerDown(eventData);
    }
}
