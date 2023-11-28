using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject elevatorPrefab;
    public float platformDistance;
    public float platformHeight;
    public float destroyDistance;

    private bool isMovingRight = true;
    private Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 spawnPosition = new Vector3(0, platformHeight, 0);
        Instantiate(elevatorPrefab, spawnPosition, Quaternion.identity);

        // Destroy any platforms that are too far behind the player
        foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform"))
        {
            if (platform.transform.position.x < playerTransform.position.x - destroyDistance)
            {
                Destroy(platform);
            }
        }
    }
}