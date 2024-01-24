using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health;

    static EnemyManager manager;

    EnemyFollow enemyFollow;

    bool hasAttacked;
    bool isTouching;

    private void Start()
    {
        manager = GetComponent<EnemyManager>(); // Just grabbing a few values from EnemyManager.cs
    }
    private void Update()
    {
        while (isTouching && !hasAttacked)
        {
            Attack();
        }
        if (health <= 0)
        {
            if (manager != null)
            {
                manager.enemiesAlive--;
            }
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Touching player!");
            isTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("No longer touching player inappropriately");
            isTouching = false;
        }
    }

    void Attack()
    {
        hasAttacked = true;
        Debug.Log("Attacking!");
        StartCoroutine(AttackCooldown(1f));
    }

    IEnumerator AttackCooldown(float atkDelay)
    {
        yield return new WaitForSeconds(atkDelay);
        hasAttacked = false;
    }
}
