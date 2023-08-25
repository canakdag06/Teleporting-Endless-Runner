using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketShake : MonoBehaviour
{
    public float shakeAmount = 0.1f; // Titreme miktarý
    public float shakeSpeed = 10f;   // Titreme hýzý

    private Vector3 originalPosition;
    private float time;

    private void Start()
    {
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        time += Time.deltaTime;

        // Füze objesini yerel koordinatlarýna göre belirli bir aralýkta titretme iþlemi.
        float Offset = Mathf.Sin(time * shakeSpeed) * shakeAmount;
        Vector3 newPosition = originalPosition + new Vector3(Offset, Offset, 0f);
        transform.localPosition = newPosition;
    }
}
