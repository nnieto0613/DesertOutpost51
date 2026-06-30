using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Required for reloading the scene!

public class TimerScript : MonoBehaviour 
{
    [Header("Timer Settings")]
    public float timeRemaining = 300f; 
    public bool timerIsRunning = false;
    
    [Header("UI References")]
    public TextMeshProUGUI timeText;
    public GameObject gameOverPanel; // New slot for our UI screen

    private void Start()
    {
        UpdateTimerDisplay(timeRemaining); 
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(timeRemaining);
                TriggerGameOver();
            }
        }
    }

    public void StartCountdown()
    {
        timerIsRunning = true;
        Debug.Log("Cutscene ended. Timer Started!");
    }

    private void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay += 1; 
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (timeRemaining <= 30f)
        {
            timeText.color = Color.red;
        }
    }

    private void TriggerGameOver()
    {
        // 1. Show the Game Over Screen
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        
        // 2. Unlock the mouse so the player can click the restart button
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // 3. Pause the game (stops physics and movement)
        Time.timeScale = 0f;
    }

    // The Button will trigger this method
    public void RestartGame()
    {
        // Unpause the game before we reload
        Time.timeScale = 1f;
        
        // Save a secret flag telling the game to skip the cutscene on the next load
        PlayerPrefs.SetInt("SkipCutscene", 1);
        
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}