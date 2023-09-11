using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShake : MonoBehaviour
{
    public float shakeAmount = 0.1f;
    public float shakeSpeed = 10f;

    private Vector3 originalPosition;
    private float time;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        time += Time.deltaTime;

        // The process of vibrating the missile object in a certain range according to its local coordinates.
        float Offset = Mathf.Sin(time * shakeSpeed) * shakeAmount;
        Vector3 newPosition = originalPosition + new Vector3(Offset, Offset, 0f);
        transform.localPosition = newPosition;
    }
}
