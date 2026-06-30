using UnityEngine;
using UnityEngine.Playables; // We need this to talk to the Timeline!

public class CutsceneTrigger : MonoBehaviour
{
    [Header("Connections")]
    public PlayableDirector cutsceneDirector;
    public TimerScript gameTimer;


    void Start()
    {
        // Check if we just hit the restart button
        if (PlayerPrefs.GetInt("SkipCutscene", 0) == 1)
        {
            // Reset the flag so it plays normally the next time you open the game fresh
            PlayerPrefs.SetInt("SkipCutscene", 0);
            
            // Fast-forward and stop the cutscene immediately
            if (cutsceneDirector != null)
            {
                cutsceneDirector.time = cutsceneDirector.duration;
                cutsceneDirector.Evaluate();
                cutsceneDirector.Stop(); 
            }
            
            // The timer will auto-start because stopping the director fires the OnCutsceneEnded event!
        }
    }



    void OnEnable()
    {
        // This tells Unity to "listen" for the exact moment the cutscene stops
        if (cutsceneDirector != null)
        {
            cutsceneDirector.stopped += OnCutsceneEnded;
        }
    }

    void OnDisable()
    {
        // Safety cleanup so Unity doesn't get confused if the scene restarts
        if (cutsceneDirector != null)
        {
            cutsceneDirector.stopped -= OnCutsceneEnded;
        }
    }

    // This runs automatically the moment the Playable Director stops playing
    void OnCutsceneEnded(PlayableDirector pd)
    {
        if (gameTimer != null)
        {
            gameTimer.StartCountdown();
            Debug.Log("Cutscene finished or skipped! Timer started.");
        }
    }
}