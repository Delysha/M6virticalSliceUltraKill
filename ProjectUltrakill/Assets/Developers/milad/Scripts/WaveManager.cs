using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int currentWaveSize, enemiesSpawned, enemiesAlive;
    public int currentWaveNumber = 1;

    float spawnInterval = 2.5f;

    public Transform[] spawnpoint;
    public GameObject enemyObj;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveNumber == 1)
        {
            
        }
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemyObj, spawnpoint[0].position, Quaternion.identity);
        Debug.Log("Enemy spawned!");
        enemiesAlive++;
        enemiesSpawned++;
        yield return new WaitForSeconds(spawnInterval);
    }
}
