using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform player;
    public bool touchingPlayer;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Look for object with "Player" tag.
    }

    // Update is called once per frame
    void Update()
    {
        if (!touchingPlayer)
        {
            enemy.SetDestination(player.position); // Setting a destination in the NavMesh component for the object when not touching the player.
        }
    }
}
