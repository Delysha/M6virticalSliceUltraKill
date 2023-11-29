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
                if (hit.collider.CompareTag("EnemyTest"))
                {
                    Debug.Log("Enemy hit");
                    Destroy(hit.collider.gameObject);
                }
                else
                {
                    Debug.Log("Enemy not hit");
                }
            }

            timeSinceLastShot = 0f;
            canShoot = false;
        }
    }
}
