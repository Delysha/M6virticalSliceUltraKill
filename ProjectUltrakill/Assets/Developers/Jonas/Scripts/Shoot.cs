using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;

    public Camera fpsCam;
    public Animator animator;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("charge");
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Debug.Log("shoot");
        }
    }

    void shoot()
    {
        animator.SetTrigger("ShootTrigger");
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.collider.CompareTag("EnemyTest"))
            {
                Debug.Log("Enemy hit");
            }
            else
            {
                Debug.Log("Enemy not hit");
            }
        }
    }
}
