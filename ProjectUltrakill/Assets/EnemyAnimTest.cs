using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAnimTest : MonoBehaviour
{
    Animator animator;
    public UnityEvent functionListener;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the animator component, needed to make sure our enemy moves.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowWalkAnim()
    {
        animator.SetTrigger("AttackToWalk");
    }

    public void ShowAttackAnim()
    {
        animator.SetTrigger("WalkToAttack");
    }
}
