using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float shootingCooldown = 0.1f;

    private bool canShoot = true;
    private float timeSinceLastShot = 0f;

    public bool TrailTrue = false;

    public Camera fpsCam;
    public Animator animator;
    public Vector3 endPos;
    Enemy enemy = null;

    private void Start()
    {
        
    }

    void Update()
    {
        if (canShoot && Input.GetButton("Fire1"))
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

        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootingCooldown)
        {
            canShoot = true;
        }
    }

    void shoot()
    {
        if (canShoot)
        {
            TrailTrue = true;
            animator.SetTrigger("ShootTrigger");
            RaycastHit hit;
            if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
            {
<<<<<<< HEAD
                endPos = hit.point;
=======
                Enemy hitEnemy = hit.collider.GetComponent<Enemy>();

>>>>>>> enemySpawning
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy hit");
                    hitEnemy.health -= damage;
                }
                else
                {
                    Debug.Log("Aimlabs is free to download, you know?");
                }
            }

            timeSinceLastShot = 0f;
            canShoot = false;
        }
    }
}
