using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public GameObject gameBoard;
    public GameObject endPanel;
    [SerializeField] TextMeshProUGUI resultTMP;

    ScoreManager scoreManager;
    TimeManager timeManager;
    GameManager gameManager;

    private void OnEnable()
    {
        scoreManager = GetComponent<ScoreManager>();
        timeManager = GetComponent<TimeManager>();
        gameManager = GetComponent<GameManager>();
        gameManager.onGameFinished.AddListener(HandleEndGameAndDisplayResults);
    }

    public void HandleEndGameAndDisplayResults()
    {
        gameBoard.SetActive(false);
        endPanel.SetActive(true);

        if (scoreManager.totalPointsP1 > scoreManager.totalPointsP2)
        {
            resultTMP.text = "VICTORIA";
            resultTMP.color = Color.green;
        }
        else if (scoreManager.totalPointsP1 < scoreManager.totalPointsP2)
        {
            resultTMP.text = "DERROTA";
            resultTMP.color = Color.red;
        }
        else
        {
            resultTMP.text = "EMPATE";
            resultTMP.color = Color.yellow;
        }

        timeManager.endScreenTimer -= Time.deltaTime;

        if (timeManager.endScreenTimer <= 0)
        {
            gameManager.ResetGame();
        }
    }

    private void OnDisable()
    {
        gameManager.onGameFinished.RemoveListener(HandleEndGameAndDisplayResults);
    }
}
