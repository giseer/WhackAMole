using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerControl : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;

    public void OnPlay()
    {
        Debug.Log("OnPlay");
        videoPlayer.Play();
        Debug.Log("OnPlay - Finished");
    }

    public void OnRestart()
    {
        int a = 10;
        int b = 20;
        int c = a + b;
        int d = c / b;

        Debug.Log("OnRestart");
        videoPlayer.Stop();
        videoPlayer.Play();
        Debug.Log("OnRestart - Finished");
    }

    public void OnStop()
    {
        Debug.Log("OnStop");
        videoPlayer.Pause();
        Debug.Log("OnStop - Finished");
    }
}
