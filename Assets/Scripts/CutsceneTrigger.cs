using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    [Header("Connections")]
    public PlayableDirector cutsceneDirector;
    public TimerScript gameTimer; // Ensure this matches your renamed TimerScript!

    // A lock so we don't accidentally trigger the timer a hundred times a second
    private bool hasTriggered = false; 

    void Start()
    {
        // Check if we just hit the restart button
        if (PlayerPrefs.GetInt("SkipCutscene", 0) == 1)
        {
            PlayerPrefs.SetInt("SkipCutscene", 0);
            
            // Fast-forward and stop the cutscene immediately
            if (cutsceneDirector != null)
            {
                cutsceneDirector.time = cutsceneDirector.duration;
                cutsceneDirector.Evaluate();
                cutsceneDirector.Stop(); 
            }
        }
    }

    void Update()
    {
        // Actively monitor the cutscene every single frame
        if (cutsceneDirector != null && !hasTriggered)
        {
            // If the cutscene is no longer playing, OR its current time has reached its maximum duration...
            if (cutsceneDirector.state != PlayState.Playing || cutsceneDirector.time >= cutsceneDirector.duration)
            {
                hasTriggered = true; // Lock the trigger so it only fires once
                
                if (gameTimer != null)
                {
                    gameTimer.StartCountdown();
                    Debug.Log("Cutscene has ended naturally or was skipped. Waiting for player movement!");
                }
            }
        }
    }
}