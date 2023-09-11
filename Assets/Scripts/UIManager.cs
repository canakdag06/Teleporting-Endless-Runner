using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] NewPlayerController playerController;
    TMP_Text scoreText;
    private float distance;

    void Start()
    {
        scoreText = GetComponentInChildren<TMP_Text>();
    }

    void Update()
    {
        distance = playerController.GetDistance();
        int intValue = Mathf.FloorToInt(distance);
        scoreText.text = intValue.ToString() + " m";
    }
}
