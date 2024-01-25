using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    [SerializeField] MoleSystemManager moleSystemP1;
    [SerializeField] MoleSystemManager moleSystemP2;

    [HideInInspector] public UnityEvent onGameFinished;

    ScoreManager scoreManager;
    TimeManager timeManager;
    GameLogic gameLogic;

    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        timeManager = GetComponent<TimeManager>();
        gameLogic = GetComponent<GameLogic>();
        ResetGame();
    }

    private void Update()
    {
        timeManager.UpdateTimerTextAndCountdownTimer();
        scoreManager.UpdatePlayerPointsTextWithScores();
        if (timeManager.gameTime <= 0f)
        {
            onGameFinished.Invoke();
        }
    }

    public void ResetGame()
    {
        timeManager.gameTime = timeManager.initialSecondsOfGameInSeconds;
        timeManager.endScreenTimer = timeManager.initialEndScreenTimer;
        scoreManager.totalPointsP1 = 0;
        scoreManager.totalPointsP2 = 0;
        gameLogic.gameBoard.SetActive(true);
        gameLogic.endPanel.SetActive(false);
        moleSystemP1.timerToSpawnMoles = moleSystemP1.initialTimeToSpawnMoles;
        moleSystemP2.timerToSpawnMoles = moleSystemP2.initialTimeToSpawnMoles;

    }
}
