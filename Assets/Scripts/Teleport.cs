using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    //private Transform myLocation;
    //Vector3 startPos;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    private float offset;
    [SerializeField] RoadManager roadManager;

    void Start()
    {
    }

    void Update()
    {
        if(transform.position.z > endPos.position.z)
        {
            roadManager.SetUpRoads();
            offset = transform.position.z - endPos.position.z;
            transform.position = new Vector3(transform.position.x, transform.position.y, startPos.position.z + offset);
        }
    }
}
