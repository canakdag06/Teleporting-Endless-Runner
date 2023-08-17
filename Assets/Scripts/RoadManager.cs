using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public Transform player;
    [Tooltip("Ýlk ve son yol ayný olmalý.")]
    public List<Road> roadPieces;
    private float pieceLength; // Length of a single piece

    private Road firstRoad;
    private Road currentRoad;

    void Start()
    {
        Vector3 localScale = roadPieces[0].transform.GetChild(0).localScale;
        pieceLength = localScale.z;
        SetUpRoads();
    }

    void Update()
    {
        ArrangeRoads();
    }

    public void SetUpRoads()
    {
        foreach (var road in roadPieces)
        {
            road.gameObject.SetActive(false);
        }
        firstRoad = roadPieces.First();
        currentRoad = firstRoad;
        currentRoad.gameObject.SetActive(true);
        currentRoad.nextRoad.gameObject.SetActive(true);
    }

    private void ArrangeRoads()
    {
        if (currentRoad != null)
        {
            if (player.position.z > currentRoad.endPosition.z + (pieceLength/3))
            {
                currentRoad = currentRoad.nextRoad;
                currentRoad.prevRoad.gameObject.SetActive(false);
                currentRoad.nextRoad.gameObject.SetActive(true);
            }
        }
    }
}