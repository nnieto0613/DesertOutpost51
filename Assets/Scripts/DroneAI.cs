using UnityEngine;

public class DroneAI : MonoBehaviour
{
    public Transform[] waypoints;
    public Transform player;

    public float patrolSpeed = 10f;
    public float chaseSpeed = 8f;
    public float detectionRange = 12f;
    public float loseRange = 18f;
    public float attackRange = 2f;
    public int damageAmount = 10;
    public float attackCooldown = 1.5f;

    private int currentWaypointIndex = 0;
    private bool chasingPlayer = false;
    private float lastAttackTime = 0f;

    void Update()
    {
        if (player == null || waypoints.Length == 0)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (!chasingPlayer && distanceToPlayer <= detectionRange)
            chasingPlayer = true;

        if (chasingPlayer && distanceToPlayer >= loseRange)
            chasingPlayer = false;

        if (chasingPlayer)
            ChasePlayer(distanceToPlayer);
        else
            Patrol();
    }

    void Patrol()
    {
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        MoveToward(targetWaypoint.position, patrolSpeed);

        Vector3 droneFlat = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 waypointFlat = new Vector3(targetWaypoint.position.x, 0, targetWaypoint.position.z);

        float distance = Vector3.Distance(droneFlat, waypointFlat);

        if (distance < 2f)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= waypoints.Length)
                currentWaypointIndex = 0;
        }
    }

    void ChasePlayer(float distanceToPlayer)
    {
        MoveToward(player.position, chaseSpeed);

        if (distanceToPlayer <= attackRange && Time.time >= lastAttackTime + attackCooldown)
        {
            lastAttackTime = Time.time;
            Debug.Log("Drone attacked player for " + damageAmount + " damage.");
        }
    }

    void MoveToward(Vector3 targetPosition, float speed)
    {
        Vector3 target = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

        Vector3 direction = target - transform.position;

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }

        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}