using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public int currentWaveSize, enemiesSpawned, enemiesAlive;
    [SerializeField] private int currentWaveNumber = 1;
    public Transform[] spawnpoint;
    public GameObject enemyObj;

    // Update is called once per frame
    void Update()
    {
        if (currentWaveNumber == 1)
        {
            StartCoroutine(SpawnWaveWithDelay(3, 0.25f));
            currentWaveNumber++;
        }
        else if (currentWaveNumber == 2 && enemiesAlive == 0)
        {
            StartCoroutine(SpawnWaveWithDelay(8, 0.25f));
            currentWaveNumber++;
        }
    }

    IEnumerator SpawnWaveWithDelay(int waveSize, float delayBetweenSpawns)
    {
        for (int i = 0; i < Mathf.Min(spawnpoint.Length, waveSize); i++)
        {
            Instantiate(enemyObj, spawnpoint[i].position, Quaternion.identity);
            enemiesAlive++;
            enemiesSpawned++;
            Debug.Log("Enemy spawned!");

            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }
}
