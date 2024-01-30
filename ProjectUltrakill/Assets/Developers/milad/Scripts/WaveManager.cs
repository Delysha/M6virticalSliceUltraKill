using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
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
            SpawnWave(3);
            currentWaveNumber++;
        }
        else if (currentWaveNumber == 2 && enemiesAlive == 0)
        {
            SpawnWave(8);
            currentWaveNumber++;
        }
    }

    void SpawnWave(int waveSize)
    {
        for (int i = 0; i < Mathf.Min(spawnpoint.Length, waveSize); i++)
        {
            Instantiate(enemyObj, spawnpoint[i].position, Quaternion.identity);
            enemiesAlive++;
            enemiesSpawned++;
            Debug.Log("Enemy spawned!");
        }
    }
}
