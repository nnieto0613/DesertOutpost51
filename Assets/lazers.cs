using UnityEngine;

public class lazers : MonoBehaviour
{
    public GameObject laserPrefab;
    public Transform firePoint;

    public float laserSpeed = 250f;
    public float fireRate = 20f;   // Smaller number = faster firing

    private float nextFireTime = 0f;
    private float dotProduct = 0f;
    public Transform targetObject;

    void Update()
    {
        if (targetObject != null)
       {
        Vector3 directionToTarget = targetObject.position - transform.position;
        dotProduct = Vector3.Dot(transform.forward, directionToTarget.normalized);


        if (Time.time >= nextFireTime && dotProduct > 0f)
        {
            nextFireTime = Time.time + fireRate;

            GameObject laser = Instantiate(
                laserPrefab,
                firePoint.position,
                firePoint.rotation
            );

            laser.transform.SetParent(null);
            

            Rigidbody rb = laser.GetComponent<Rigidbody>();

            if (rb == null)
            {
                rb = laser.AddComponent<Rigidbody>();
            }

            rb.useGravity = false;
            rb.velocity = firePoint.forward * laserSpeed;

            Destroy(laser, 3f);
        }
       }
    }
}