using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour
{
     public AudioSource playerSound;
    
    void OnTriggerEnter(Collider other)
    {
        PlayerMovement playerMovement = other.GetComponent<PlayerMovement>();

        if (playerMovement != null)
        {
            playerMovement.moveSpeed = playerMovement.moveSpeed - 1f;
        }
        Destroy(gameObject);
    }
}
