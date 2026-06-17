using UnityEngine;
using System.Collections;

public class PowerTerminal : MonoBehaviour
{
    public GameObject powerPrompt;
    public GameObject powerRestoredMessage;
    public Transform player;
    public float interactRange = 4f;
    public float messageDuration = 4f;

    private bool powerRestored = false;

    void Start()
    {
        if (powerPrompt != null)
            powerPrompt.SetActive(false);

        if (powerRestoredMessage != null)
            powerRestoredMessage.SetActive(false);
    }

    void Update()
    {
        if (player == null)
            return;

        float distance = Vector3.Distance(transform.position, player.position);
        bool playerNearby = distance <= interactRange;

        if (powerPrompt != null)
            powerPrompt.SetActive(playerNearby && !powerRestored);

        if (playerNearby && Input.GetKeyDown(KeyCode.E) && !powerRestored)
        {
            powerRestored = true;

            if (powerPrompt != null)
                powerPrompt.SetActive(false);

            if (powerRestoredMessage != null)
                StartCoroutine(ShowPowerRestoredMessage());

            Debug.Log("Power Restored!");
        }
    }

    IEnumerator ShowPowerRestoredMessage()
    {
        powerRestoredMessage.SetActive(true);
        yield return new WaitForSeconds(messageDuration);
        powerRestoredMessage.SetActive(false);
    }

    public bool IsPowerRestored()
    {
        return powerRestored;
    }
}