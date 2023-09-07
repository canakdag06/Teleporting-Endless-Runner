using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionVFX;

    private PlayerController playerController;
    private MeshRenderer meshRenderer;
    private CapsuleCollider capsuleCollider;
    private DeathHandler deathHandler;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        deathHandler = GetComponent<DeathHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if(other.CompareTag("Obstacle"))
            {
                Explode();
            }
        }
    }

    private void Explode()
    {
        explosionVFX.Play();
        playerController.TurnOffThrust();
        meshRenderer.enabled = false;
        playerController.enabled = false;
        capsuleCollider.enabled = false;
        deathHandler.HandleDeath();
    }
}
