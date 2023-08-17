using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    void LateUpdate()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        Vector3 position = transform.position;
        position.z = (target.position + offset).z;
        transform.position = position;
    }
}
