using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public int maxEnemyCount, enemiesSpawned, enemiesAlive;

    float spawnInterval = 2.5f;

    public Transform[] spawnpoints;
    public GameObject[] enemyObj;

    // Start is called before the first frame update
    private void Awake()
    {
        Debug.Log($"Enemy limit: {maxEnemyCount}");
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesAlive < maxEnemyCount && Time.time >= spawnInterval)
        {
            StartCoroutine(SpawnEnemy()); // Begin spawn cooldown.
            spawnInterval = Time.time + spawnInterval; // Wait until 2.5 seconds has passed or whatever spawnInterval is rn.
        }
    }

    IEnumerator SpawnEnemy()
    {
        // Instantiate the first object in the enemyObj array, pick a random position from the spawnpoints array & assign position & rotation values.
        Instantiate(enemyObj[0], spawnpoints[Random.Range(0, 4)].position, Quaternion.identity);

        Debug.Log("Enemy spawned!");
        enemiesAlive++;
        enemiesSpawned++;
        yield return new WaitForSeconds(spawnInterval); // Wait 2.5 seconds.
    }
}
