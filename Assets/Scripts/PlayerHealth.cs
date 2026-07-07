using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int lives = 3;

    [Header("Connections")]
    public TimerScript gameTimer; 
    
    // NEW: An array (a list) to hold our 3 UI rectangles
    public GameObject[] lifeIcons; 

    public void TakeDamage()
    {
        lives--; // Subtract 1 life
        Debug.Log("Player was hit! Lives remaining: " + lives);

        if (GetComponent<AudioSource>() != null)
        {
            GetComponent<AudioSource>().Play();
        }

        // NEW: Turn off the corresponding UI rectangle
        // Arrays count from 0. So if lives drop to 2, it turns off rectangle #2
        if (lives >= 0 && lives < lifeIcons.Length)
        {
            lifeIcons[lives].SetActive(false);
        }

        if (lives <= 0)
        {
            Debug.Log("Player died! Triggering Game Over.");
            if (gameTimer != null)
            {
                gameTimer.TriggerGameOver();
            }
        }
    }
}