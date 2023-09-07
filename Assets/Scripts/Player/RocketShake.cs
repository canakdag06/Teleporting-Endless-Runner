using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShake : MonoBehaviour
{
    public float shakeAmount = 0.1f; // Titreme miktar�
    public float shakeSpeed = 10f;   // Titreme h�z�

    private Vector3 originalPosition;
    private float time;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        time += Time.deltaTime;

        // F�ze objesini yerel koordinatlar�na g�re belirli bir aral�kta titretme i�lemi.
        float Offset = Mathf.Sin(time * shakeSpeed) * shakeAmount;
        Vector3 newPosition = originalPosition + new Vector3(Offset, Offset, 0f);
        transform.localPosition = newPosition;
    }
}
