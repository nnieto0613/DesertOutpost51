using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class TimerScript : MonoBehaviour 
{
    [Header("Timer Settings")]
    public float timeRemaining = 300f; 
    public bool timerIsRunning = false;
    private bool waitingForFirstMove = false; 
    
    // NEW: The Master Switch that tells the whole game if we are playing yet
    public static bool gameIsActive = false;
    
    [Header("UI References")]
    public TextMeshProUGUI timeText;
    public GameObject gameOverPanel; 
    
    // NEW: A slot for our grouped UI
    public GameObject playerHUD; 

    private void Start()
    {
        // 1. Reset the master switch when the level loads
        gameIsActive = false; 
        
        // 2. Hide the HUD while the cutscene plays
        if (playerHUD != null)
        {
            playerHUD.SetActive(false);
        }
        
        UpdateTimerDisplay(timeRemaining); 
    }

    private void Update()
    {
        if (waitingForFirstMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
            {
                waitingForFirstMove = false; 
                timerIsRunning = true;       
                
                // NEW: Flip the Master Switch to ON!
                gameIsActive = true;
                
                // NEW: Turn the UI back on!
                if (playerHUD != null)
                {
                    playerHUD.SetActive(true);
                }
                
                Debug.Log("Player moved! Timer officially ticking and Drones activated.");
            }
        }

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
        waitingForFirstMove = true;
        Debug.Log("Cutscene ended. Waiting for player to move...");
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

    public void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        
        // Hide the HUD so it doesn't overlap the Game Over screen
        if (playerHUD != null)
        {
            playerHUD.SetActive(false);
        }
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("SkipCutscene", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}