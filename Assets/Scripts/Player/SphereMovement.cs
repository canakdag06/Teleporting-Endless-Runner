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
    private void Start()
    {
    }

    private void Update()
    {
        AdjustZ();
        TouchInput();
    }

    private void AdjustZ()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, missilePos.position.z);
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
                newVector = new Vector3(
                    transform.position.x + touch.deltaPosition.x * speedModifier,
                    transform.position.y,
                    transform.position.z);
                Debug.Log(newVector);
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