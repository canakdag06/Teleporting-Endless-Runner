using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] Transform portal1, portal2;       // for copying the thrust particle effect
    [SerializeField] Transform player;

    void Update()
    {
        float zPos = portal2.position.z - portal1.position.z;
        transform.position = new Vector3(player.position.x, player.position.y, player.position.z - zPos);
    }
}
