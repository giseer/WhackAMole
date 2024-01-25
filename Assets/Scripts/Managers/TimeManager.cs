using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTMP;

    public float initialSecondsOfGameInSeconds = 60f;

    public float gameTime;

    public float initialEndScreenTimer = 5f;
    public float endScreenTimer;

    public void UpdateTimerTextAndCountdownTimer()
    {
        timerTMP.text = $"{(int)gameTime}";

        if (gameTime < 1f)
        {
            gameTime = 0;
        }
        else
        {
            gameTime -= Time.deltaTime;
        }
    }
}
