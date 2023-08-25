using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
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
    private PlayerControls controls;

    private Vector2 vector;

    Vector3 velocity;
    [SerializeField] float velocityLerpValue = 10;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        controls = new PlayerControls();
        controls.Player.Enable();
    }

    private void Update()
    {
        SpeedUp();
        ProcessTranslation();
        ProcessRotation();
        VelocityLerp();
    }

    void VelocityLerp()
    {
        velocity = Vector3.Lerp(velocity, vector, velocityLerpValue * Time.deltaTime);
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
        //xThrow = controls.Player.Move.ReadValue<float>();
        xThrow = velocity.x * 5f;
        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    public void GetVector(Vector2 joystickVector)
    {
        vector = joystickVector;
    }

    private void ProcessRotation()
    {
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, roll);
    }
   
}