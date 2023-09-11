using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    /* ------------------------------------ NOT USED -------------------------------*/
    [SerializeField] float speed = 10f;
    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float speedIncrease = 1f;
    [SerializeField] float controlSpeed = 1f;
    [SerializeField] float xRange = 5f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float controlRollFactor = -10f;
    float xThrow;

    private Vector2 vector;

    private float distance;

    [Header("Horizontal Lerping")]
    Vector3 velocity;
    [SerializeField] float velocityLerpValue = 10;

    [Header("Fuel & No-Fuel Situation")]
    public FuelManager fuelManager;
    float currentFuel;
    public float fuelConsumptionRate;
    public float fallSpeed;
    public float rotationSpeed;
    private bool isFalling = false;

    [SerializeField] public ParticleSystem thrustVFX;


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
        thrustVFX.Play();
        if (speed < maxSpeed)
        {
            speed += speedIncrease * Time.deltaTime;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        distance += 1 * Time.deltaTime * 100;    // for score
        currentFuel = fuelManager.ConsumeFuel(fuelConsumptionRate * Time.deltaTime);    // consuming fuel

        if (currentFuel <= 0)
        {
            Fall();
        }
    }

    public float GetDistance()  // for UI
    {
        return distance;
    }

    public void ProcessTranslation()
    {
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

    public void Fall()
    {
        isFalling = true;
        thrustVFX.Stop();
        float fallDistance = Time.deltaTime * fallSpeed;
        Vector3 newPosition = transform.position;
        newPosition.y -= fallDistance;
        transform.position = newPosition;

        Quaternion targetRotation = Quaternion.Euler(90, 0, 0); // -90 derece X eksenine dönme
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void TurnOffThrust()
    {
        thrustVFX.Stop();
    }

    private void ProcessRotation()
    {
        if(!isFalling)
        {
            float roll = xThrow * controlRollFactor;
            transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, roll);
        }
    }
   
}