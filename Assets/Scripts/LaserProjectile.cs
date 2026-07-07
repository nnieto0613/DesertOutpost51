using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    // This runs the millisecond the laser's collider touches another collider
    void OnTriggerEnter(Collider other)
    {
        // Check if the thing we hit is wearing the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Find the health script on the player
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            
            if (health != null)
            {
                health.TakeDamage(); // Hurt the player
            }

            // Destroy the laser immediately so it doesn't pass through and hit them twice
            Destroy(gameObject);
        }
    }
}