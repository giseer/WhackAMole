using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI playerPointsP1TMP;
    public TextMeshProUGUI playerPointsP2TMP;

    public int totalPointsP1;
    public int totalPointsP2;

    public void UpdatePlayerPointsTextWithScores()
    {
        playerPointsP1TMP.text = $"{totalPointsP1}";
        playerPointsP2TMP.text = $"{totalPointsP2}";
    }

    public void IncrementPlayerPoints(int pointsToAdd, int playerScoredNum)
    {
        if (playerScoredNum == 1)
        {
            totalPointsP1 += pointsToAdd;
        }
        else if (playerScoredNum == 2)
        {
            totalPointsP2 += pointsToAdd;
        }
    }

}
