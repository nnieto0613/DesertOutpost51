using UnityEngine;

public class lazers : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;

    public float laserSpeed = 250f;
    public float fireRate = 2f;    // Changed to 2f (20f means it waits 20 seconds between shots!)

    private float nextFireTime = 0f;
    private float dotProduct = 0f;
    public Transform targetObject;

    void Update()
    {   
        if (TimerScript.gameIsActive == false) return;

        if (targetObject != null)
        {
            Vector3 directionToDrone = targetObject.position - transform.position;
            dotProduct = Vector3.Dot(transform.forward, directionToDrone.normalized);

            // If it's time to fire AND the player is in front of the drone
            if (Time.time >= nextFireTime && dotProduct > 0f)
            {
                nextFireTime = Time.time + fireRate;

                // 1. Calculate exactly where the player's chest is
                Vector3 aimTarget = targetObject.position + (Vector3.up * 1.5f);
                Vector3 directionToPlayer = (aimTarget - firePoint.position).normalized;

                // 2. Spawn the laser
                GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
                laser.transform.SetParent(null);
                
                // 3. Make the physical laser model rotate to look at the player
                laser.transform.LookAt(aimTarget);

                Rigidbody rb = laser.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = laser.AddComponent<Rigidbody>();
                }

                rb.useGravity = false;
                
                // 4. Send the laser flying exactly toward the player!
                rb.velocity = directionToPlayer * laserSpeed;

                Destroy(laser, 3f);
            }
        }
    }
}