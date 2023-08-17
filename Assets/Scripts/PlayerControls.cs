using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float speedIncrease = 1f;
    [SerializeField] float controlSpeed = 1f;
    [SerializeField] float xRange = 5f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float controlRollFactor = -10f;
    float xThrow;

    private PlayerInput playerInput;
    private Controls controls;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controls = new Controls();
        controls.Player.Enable();
       /* controls.Player.Move.performed += Movement_performed; */  // Insert Events
    }

    private void Update()
    {
        SpeedUp();
        ProcessTranslation();
        ProcessRotation();
    }

    private void SpeedUp()
    {
        if (speed < maxSpeed)
        {
            speed += speedIncrease * Time.deltaTime;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void ProcessTranslation()
    {
        xThrow = controls.Player.Move.ReadValue<float>();
        Debug.Log(xThrow);
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    void ProcessRotation()
    {
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, roll);
    }
}
