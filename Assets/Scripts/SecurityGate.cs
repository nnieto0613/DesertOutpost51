using UnityEngine;

public class SecurityGate : MonoBehaviour
{
    public Transform gate;
    public GameObject gatePrompt;

    public string requiredItemName = "Security Key";
    public float openHeight = 6f;
    public float openSpeed = 3f;

    private bool playerNearby = false;
    private bool opening = false;
    private PlayerPickup playerPickup;

    private Vector3 closedPosition;
    private Vector3 openPosition;

    void Start()
    {
        if (gate != null)
        {
            closedPosition = gate.position;
            openPosition = closedPosition + Vector3.up * openHeight;
        }

        if (gatePrompt != null)
        {
            gatePrompt.SetActive(false);
        }
    }

    void Update()
    {
        if (gatePrompt != null)
        {
            gatePrompt.SetActive(playerNearby && !opening);
        }

        if (playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (playerPickup != null && playerPickup.HasHeldItem(requiredItemName))
            {
                playerPickup.RemoveHeldItem();

                if (gatePrompt != null)
                {
                    gatePrompt.SetActive(false);
                }

                opening = true;
                Debug.Log("Security Gate Unlocked!");
            }
            else
            {
                Debug.Log("You need the Security Key.");
            }
        }

        if (opening && gate != null)
        {
            gate.position = Vector3.MoveTowards(
                gate.position,
                openPosition,
                openSpeed * Time.deltaTime
            );
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPickup pickup = other.GetComponent<PlayerPickup>();

        if (pickup != null)
        {
            playerNearby = true;
            playerPickup = pickup;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerPickup pickup = other.GetComponent<PlayerPickup>();

        if (pickup != null)
        {
            playerNearby = false;
            playerPickup = null;
        }
    }
}