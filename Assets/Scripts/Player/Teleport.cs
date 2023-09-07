using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    private float offset;
    [SerializeField] RoadManager roadManager;

    [SerializeField] GameObject portal1, portal2;       // for copying the thrust particle effect
    [SerializeField] ParticleSystem thrust, thrustCopy;
    private Vector3 particalDistance;

    private void Start()
    {
        particalDistance = portal2.transform.position - portal1.transform.position; // calculates the distance between 2 portals
        thrustCopy.transform.position = this.gameObject.transform.position - particalDistance;
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



//if (Input.GetKeyDown(KeyCode.L))
//{
//    ParticleSystem.Particle[] m_Particles = null;
//    int numParticlesAlive = thrustParticle.GetParticles(m_Particles);

//    Vector3[] offsets = new Vector3[m_Particles.Length];

//    for (int i = 0; i < m_Particles.Length; i++)
//    {
//        offsets[i] = transform.position - m_Particles[i].position;
//    }
//    transform.Translate(Vector3.forward * 100);

//    for (int i = 0; i < m_Particles.Length; i++)
//    {
//        m_Particles[i].position = transform.position - offsets[i];
//    }

//    thrustParticle.SetParticles(m_Particles, numParticlesAlive);
//}

//if (Input.GetKeyDown(KeyCode.K))
//{
//    thrustParticle.simulationSpace = ParticleSystemSimulationSpace.World;
//}