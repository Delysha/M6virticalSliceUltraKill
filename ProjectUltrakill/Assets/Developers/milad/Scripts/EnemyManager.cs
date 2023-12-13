using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int currentWaveSize, enemiesSpawned, enemiesAlive;

    float spawnInterval = 2.5f;

    public Transform[] spawnpoints;
    public GameObject[] enemyObj;

    // Start is called before the first frame update
    private void Awake()
    {
        currentWaveSize += 5;
        Debug.Log($"Enemy limit: {currentWaveSize}");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive < currentWaveSize && Time.time >= spawnInterval)
        {
            StartCoroutine(SpawnEnemy());
            spawnInterval = Time.time + spawnInterval;
        }
    }

    IEnumerator SpawnEnemy()
    {
        Instantiate(enemyObj[0], spawnpoints[0].position, Quaternion.identity);
        Debug.Log("Enemy spawned!");
        enemiesAlive++;
        enemiesSpawned++;
        yield return new WaitForSeconds(spawnInterval);
    }
}