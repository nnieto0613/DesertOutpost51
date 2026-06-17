using UnityEngine;

public class EscapeZone : MonoBehaviour
{
    public PowerTerminal powerTerminal;
    public Transform player;
    public float escapeRange = 5f;

    public GameObject missionCompleteText;
    public GameObject needPowerText;
    public GameObject powerRestoredText;

    private bool missionComplete = false;

    void Start()
    {
        if (missionCompleteText != null)
            missionCompleteText.SetActive(false);

        if (needPowerText != null)
            needPowerText.SetActive(false);
    }

    void Update()
    {
        if (player == null || missionComplete)
            return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= escapeRange)
        {
            if (powerTerminal != null && powerTerminal.IsPowerRestored())
            {
                missionComplete = true;

                if (powerRestoredText != null)
                    powerRestoredText.SetActive(false);

                if (needPowerText != null)
                    needPowerText.SetActive(false);

                if (missionCompleteText != null)
                    missionCompleteText.SetActive(true);

                Debug.Log("Mission Complete!");
            }
            else
            {
                if (needPowerText != null)
                    needPowerText.SetActive(true);

                Debug.Log("Restore power before escaping.");
            }
        }
        else
        {
            if (needPowerText != null)
                needPowerText.SetActive(false);
        }
    }
}