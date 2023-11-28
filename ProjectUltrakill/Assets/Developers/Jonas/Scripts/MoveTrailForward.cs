using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrailForward : MonoBehaviour
{
    private float speed = 600;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        Destroy(gameObject);
        Debug.Log("lock in brah");
    }
}
