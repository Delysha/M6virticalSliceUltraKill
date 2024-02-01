using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health;
    [SerializeField] float attackCooldown = 2f;
    [SerializeField] int enemyDamageValue;

    Animator animator;
    PlayerHealth hp;
    WaveManager waveManager;
    public GameObject bloodParticle;

    bool isTouching;
    bool hasAttacked;

    void Start()
    {
        animator = GetComponent<Animator>();
        waveManager = FindObjectOfType<WaveManager>();

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
            isTouching = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTouching = false;
            animator.SetTrigger("AttackToWalk");
        }
    }

    void Die()
    {
        waveManager.enemiesAlive--;
        Vector3 bloodParticlePosition = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        Instantiate(bloodParticle, bloodParticlePosition, Quaternion.Euler(-90f, 0f, 0f));
        Destroy(gameObject);
    }
}
