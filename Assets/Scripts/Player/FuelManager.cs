using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelManager : MonoBehaviour
{
    public float maxFuel = 100f;
    public Gradient fuelGradient;

    private float currentFuel;
    private Slider fuelSlider;

    public Image warningIcon;
    public float blinkInterval = 2f;
    public float lowFuelThreshold = 30f;
    private bool isLowFuel = false;



    void Start()
    {
        fuelSlider = FindObjectOfType<Slider>();
        currentFuel = maxFuel;
    }

    private void Update()
    {
        if (currentFuel <= lowFuelThreshold && !isLowFuel)
        {
            isLowFuel = true;
            StartCoroutine(BlinkWarningIcon());
        }
        else if (currentFuel > lowFuelThreshold && isLowFuel)
        {
            isLowFuel = false;
            StopCoroutine(BlinkWarningIcon());
            warningIcon.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fuel"))
        {
            GetFuel(other);
            RefillFuel(50f);
        }
    }

    public float ConsumeFuel(float ammount)
    {
        currentFuel = Mathf.Max(currentFuel - ammount, 0);
        fuelSlider.value = currentFuel / maxFuel;
        fuelSlider.fillRect.GetComponent<Image>().color = fuelGradient.Evaluate(fuelSlider.value);
        return currentFuel;
    }

    private void GetFuel(Collider fuel)
    {
        fuel.gameObject.SetActive(false);
    }

    public void RefillFuel(float amount)
    {
        currentFuel = Mathf.Min(currentFuel + amount, maxFuel);
    }

    private IEnumerator BlinkWarningIcon()
    {
        while (isLowFuel)
        {
            warningIcon.enabled = !warningIcon.enabled;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
