using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] float attackCooldown = 2f;
    [SerializeField] int enemyDamageValue;

    EnemyManager manager;
    Animator animator;
    PlayerHealth hp;
    bool isTouching;
    bool hasAttacked;

    void Start()
    {
        manager = GetComponent<EnemyManager>();
        animator = GetComponent<Animator>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            hp = player.GetComponent<PlayerHealth>(); // Get the PlayerHealth component from the player GameObject
        }
        else
        {
            Debug.LogError("Player GameObject not found!");
        }
    }

    void Update()
    {
        // Check if the enemy is touching the player and hasn't attacked yet
        if (isTouching && !hasAttacked)
        {
            Attack();
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Attack()
    {
        hasAttacked = true;
        animator.Play("attack filth");
        animator.SetTrigger("AttackToIdle");
        Debug.Log("Attacking!");
        StartCoroutine(ResetAttackCooldown());
        hp.health -= enemyDamageValue;
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        hasAttacked = false;
        yield return new WaitForSeconds(attackCooldown);
        animator.SetTrigger("IdleToAttack");
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
            Debug.Log("No longer touching player.");
            isTouching = false;
            animator.SetTrigger("AttackToWalk");
        }
    }


    void Die()
    {
        if (manager != null)
        {
            manager.enemiesAlive--;
        }
        Debug.Log("Enemy killed.");
        Destroy(gameObject);
    }
}
