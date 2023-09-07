using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] NewPlayerController playerController;
    TMP_Text scoreText;

    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = playerController.GetDistance();
        int intValue = Mathf.FloorToInt(distance);
        scoreText.text = intValue.ToString() + " m";
    }
}
