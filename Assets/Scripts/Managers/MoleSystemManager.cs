using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;


public class MoleSystemManager : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] GameObject molePrefab;
    [SerializeField] int playerNum;

    DynamicMoleSpawnTimesBasedOnGameTime timeAdjust;

    public float initialTimeToSpawnMoles;

    public float timerToSpawnMoles;

    int holeNumber;

    bool isMoleSpawned;

    private void Start()
    {
        timeAdjust = GetComponent<DynamicMoleSpawnTimesBasedOnGameTime>();
        initialTimeToSpawnMoles = timeAdjust.secondsToSpawnMole60_50;
        timerToSpawnMoles = initialTimeToSpawnMoles;
    }

    private void Update()
    {
        if (timeManager.gameTime > 1f)
        {
            SpawnRandomMoleWithTimer();
        }
    }

    private void SpawnRandomMoleWithTimer()
    {

        timeAdjust.AdjustMoleSpawnTimesBasedOnGameTime();

        timerToSpawnMoles += Time.deltaTime;

        isMoleSpawned = false;

        holeNumber = (int)Random.Range(0, transform.childCount);

        if (timerToSpawnMoles >= timeAdjust.secondsToSpawnMole)
        {
            for (int i = holeNumber; !isMoleSpawned; i++)
            {
                if (i >= transform.childCount)
                {
                    i = 0;
                }

                if (transform.GetChild(i).childCount == 0)
                {
                    GameObject moleInstantiate = Instantiate(molePrefab, transform.GetChild(i).transform);
                    if (playerNum == 2)
                    {
                        moleInstantiate.transform.Rotate(new Vector3(180, 0, 0));
                    }
                    StartCoroutine(DestroyMoleObject(moleInstantiate));
                    isMoleSpawned = true;
                }

            }
            timerToSpawnMoles = 0;
        }
    }

    IEnumerator DestroyMoleObject(GameObject moleInstantiate)
    {
        yield return new WaitForSeconds(timeAdjust.secondsToDespawnMole);

        Destroy(moleInstantiate);
    }
}
