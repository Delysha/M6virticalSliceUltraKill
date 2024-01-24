using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrail : MonoBehaviour
{
    public GameObject TrailPrefab;
    public Transform shootPos;
    public ShootScript shoot;
    void Start()
    {

    }

    private void Update()
    {
        if (shoot.trailTrue)
        {
            Instantiate(TrailPrefab, shootPos.position, shootPos.rotation);
            shoot.trailTrue = false;
            Debug.Log("trail instantiated");
        }
    }
}
