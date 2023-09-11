using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class NewPlayerController : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float speedIncrease = 1f;
    [SerializeField] float controlSpeed = 1f;
    [SerializeField] float xRange = 5f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float controlRollFactor;
    float xThrow;

    [Header("Fuel & No-Fuel Situation")]
    public FuelManager fuelManager;
    float currentFuel;
    public float fuelConsumptionRate;
    public float fallSpeed;
    public float rotationSpeed;
    private bool isFalling = false;

    private float distance;

    [SerializeField] public ParticleSystem thrustVFX;

    private Vector2 vector;

    [SerializeField] Transform sphere;
    [SerializeField] float followSpeed;
    [SerializeField] float lookSpeed;
 
    void Update()
    {
        SpeedUp();
        FollowSphere();
        ProcessRotation();
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

    private void FollowSphere()
    {
        Vector3 targetPos = new Vector3(sphere.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }
    public void Fall()
    {
        isFalling = true;
        thrustVFX.Stop();
        float fallDistance = Time.deltaTime * fallSpeed;
        Vector3 newPosition = transform.position;
        newPosition.y -= fallDistance;
        transform.position = newPosition;

        Quaternion targetRotation = Quaternion.Euler(90, 0, 0); // -90 deg X Rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void TurnOffThrust()
    {
        thrustVFX.Stop();
    }

    public float GetDistance()  // for UI
    {
        return distance;
    }

    public void ProcessTranslation()
    {
        xThrow = vector.x;
        float xOffset = xThrow * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        if (!isFalling)
        {
            Vector3 targetDirection = sphere.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * lookSpeed);

                    // Z ROTATION ( COULDN'T MAKE IT WORK WITH THE CODE ABOVE )

            //float newRotationZ = Mathf.Lerp(0f, 45f, Mathf.Abs(targetDirection.x) / 6f);
            //Debug.Log("New Rotation Z: " + newRotationZ);
            //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, newRotationZ * lookSpeed);
        }
    }
}