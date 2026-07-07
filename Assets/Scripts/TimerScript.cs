using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; 

public class TimerScript : MonoBehaviour 
{
    [Header("Timer Settings")]
    public float timeRemaining = 299f; 
    public bool timerIsRunning = false;
    
    // NEW: A secret toggle to pause the timer until movement happens
    private bool waitingForFirstMove = false; 
    
    [Header("UI References")]
    public TextMeshProUGUI timeText;
    public GameObject gameOverPanel; 

    private void Start()
    {
        UpdateTimerDisplay(timeRemaining); 
    }

    private void Update()
    {
        // Check for Movement before timer starts
        if (waitingForFirstMove)
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");


            if (Mathf.Abs(horizontal) > 0.1f || Mathf.Abs(vertical) > 0.1f)
            {
                waitingForFirstMove = false; 
                timerIsRunning = true;       // Start the clock
                Debug.Log("Player moved! Timer officially ticking.");
            }
        }

        // timer countdown logic
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
        // Turn on the waiting toggle
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

    private void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
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