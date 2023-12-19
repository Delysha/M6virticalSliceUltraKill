using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    private Transform player;
    public bool touchingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!touchingPlayer)
        {
            enemy.SetDestination(player.position);
        }
    }
}
