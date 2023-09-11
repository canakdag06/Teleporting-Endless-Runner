using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SphereMovement : MonoBehaviour
{
    private Touch touch;
    private float speedModifier = 0.01f;
    [SerializeField] Transform missilePos;
    Vector3 newVector;
    Vector3 deltaPosition;
    [SerializeField] float xRange = 3f;

    private void Update()
    {
        AdjustZ();
        TouchInput();
    }

    private void AdjustZ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, missilePos.position.z+10f);
    }

    private void TouchInput()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == UnityEngine.TouchPhase.Moved)
            {
                deltaPosition = touch.deltaPosition * Time.deltaTime;
                deltaPosition = Vector3.Lerp(deltaPosition, touch.deltaPosition, 0.1f);
                float rawXPos = transform.position.x + touch.deltaPosition.x * speedModifier;
                float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
                newVector = new Vector3(
                    clampedXPos,
                    transform.position.y,
                    transform.position.z);
                transform.position = newVector;
            }
        }
    }

    public Vector3 GetVector()
    {
        return newVector;
    }

    public Vector3 GetDelta()
    {
        return deltaPosition;
    }
}