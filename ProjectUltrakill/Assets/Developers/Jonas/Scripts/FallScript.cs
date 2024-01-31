using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallScipt : MonoBehaviour
{
    public AudioSource land;
    public AudioSource whoosh;
    public BoxCollider boxCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player exited the tunnel, enable the wall and disable start music and delete hitbox
            whoosh.Stop();
            land.Play();
            boxCollider.enabled = false;
        }
    }
}
