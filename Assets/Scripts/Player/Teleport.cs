using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    private float offset;
    [SerializeField] RoadManager roadManager;

    private void Start()
    {
    }

    void Update()
    {
        if (transform.position.z > endPos.position.z)
        {
            roadManager.SetUpRoads();
            offset = transform.position.z - endPos.position.z;
            transform.position = new Vector3(transform.position.x, transform.position.y, startPos.position.z + offset);
        }
    }
}