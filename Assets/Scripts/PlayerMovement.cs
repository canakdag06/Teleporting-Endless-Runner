using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float maxSpeed = 50f;
    [SerializeField] float speedIncrease = 1f;
    [SerializeField] float controlSpeed = 1f;
    [SerializeField] float xRange = 10f;

    [Header("Player Input Based Tuning")]
    [SerializeField] float controlRollFactor = -10f;
    float xThrow;

    void Update()
    {
        SpeedUp();
        ProcessTranslation();
        ProcessRotation();
    }

    public void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");

        float xOffset = xThrow * Time.deltaTime * controlSpeed;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
    }

    private void SpeedUp()
    {
        if (speed < maxSpeed)
        {
            speed += speedIncrease * Time.deltaTime;
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void ProcessRotation()
    {
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, roll);
    }
}