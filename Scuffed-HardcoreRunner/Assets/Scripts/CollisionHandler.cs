using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class CollisionHandler : NetworkBehaviour
{
    /// <summary>
    /// programmed by Florentin Lüdeking
    /// </summary>
    private Vector3 spawnPosition;
    /// <summary>
    /// sets the Spawn position by taking the inital position
    /// </summary>
    private void Start()
    {
        spawnPosition = transform.position;
    }
    /// <summary>
    /// if the player hits a kill plane he gets resetted
    /// </summary>
    /// <param name="other">collider</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("KillPlane"))
        {
            RpcRespawn();
        }
    }
    /// <summary>
    /// if the player collides with an obsticle he gets resetted 
    /// </summary>
    /// <param name="other">Collisison</param>
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacles"))
        {
            RpcRespawn();
        }
    }
    /// <summary>
    /// sets the player to the spawn position
    /// </summary>
    [ClientRpc]
    private void RpcRespawn()
    {
        transform.position = spawnPosition;
    }
}
