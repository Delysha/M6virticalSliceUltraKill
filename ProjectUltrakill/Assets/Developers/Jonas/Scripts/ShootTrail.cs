using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrail : MonoBehaviour
{
    public GameObject TrailPrefab;
    public Transform shootPos;
    public Shoot shoot;
    void Start()
    {
        
    }

    private void Update()
    {
        if (shoot.TrailTrue)
        {
            Instantiate(TrailPrefab, shootPos.position, shootPos.rotation);
            shoot.TrailTrue = false;
            Debug.Log("trail instantiated");
        }
    }
}
