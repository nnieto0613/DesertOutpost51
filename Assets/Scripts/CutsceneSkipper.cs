using UnityEngine;
using UnityEngine.Playables;
using Cinemachine;

public class CutsceneSkipper : MonoBehaviour
{
    public PlayableDirector director;
    public CinemachineVirtualCamera playerCamera;
    public MonoBehaviour playerMovement;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndCutscene();
        }
    }

    public void EndCutscene()
    {
        director.Stop();

        playerCamera.Priority = 20;

        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }
    }
}