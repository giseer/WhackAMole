using UnityEngine;

public class DynamicMoleSpawnTimesBasedOnGameTime : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;

    public float secondsToSpawnMole60_50;
    [SerializeField] float secondsToSpawnMole50_40;
    [SerializeField] float secondsToSpawnMole40_30;
    [SerializeField] float secondsToSpawnMole30_20;
    [SerializeField] float secondsToSpawnMole20_10;
    [SerializeField] float secondsToSpawnMole10_0;

    public float secondsToSpawnMole;

    [SerializeField] float secondsToDespawnMole60_50;
    [SerializeField] float secondsToDespawnMole50_40;
    [SerializeField] float secondsToDespawnMole40_30;
    [SerializeField] float secondsToDespawnMole30_20;
    [SerializeField] float secondsToDespawnMole20_10;
    [SerializeField] float secondsToDespawnMole10_0;

    public float secondsToDespawnMole;

    public void AdjustMoleSpawnTimesBasedOnGameTime()
    {

        if (timeManager.gameTime <= 60 && timeManager.gameTime > 50)
        {
            secondsToSpawnMole = secondsToSpawnMole60_50;
            secondsToDespawnMole = secondsToDespawnMole60_50;
        }
        else if (timeManager.gameTime < 50 && timeManager.gameTime > 40)
        {
            secondsToSpawnMole = secondsToSpawnMole50_40;
            secondsToDespawnMole = secondsToDespawnMole50_40;
        }
        else if (timeManager.gameTime < 40 && timeManager.gameTime > 30)
        {
            secondsToSpawnMole = secondsToSpawnMole40_30;
            secondsToDespawnMole = secondsToDespawnMole40_30;
        }
        else if (timeManager.gameTime < 30 && timeManager.gameTime > 20)
        {
            secondsToSpawnMole = secondsToSpawnMole30_20;
            secondsToDespawnMole = secondsToDespawnMole30_20;
        }
        else if (timeManager.gameTime < 20 && timeManager.gameTime > 10)
        {
            secondsToSpawnMole = secondsToSpawnMole20_10;
            secondsToDespawnMole = secondsToDespawnMole20_10;
        }
        else if (timeManager.gameTime < 10 && timeManager.gameTime > 0)
        {
            secondsToSpawnMole = secondsToSpawnMole10_0;
            secondsToDespawnMole = secondsToDespawnMole10_0;
        }
    }
}
