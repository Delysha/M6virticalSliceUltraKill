using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateWall : MonoBehaviour
{
    public GameObject wall;
    public GameObject startMusic;

    private void Start()
    {
        wall.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the tunnel, enable the wall and disable start music and delete hitbox
            wall.SetActive(true);
            startMusic.SetActive(false);
            Destroy(gameObject);
        }
    }
}
