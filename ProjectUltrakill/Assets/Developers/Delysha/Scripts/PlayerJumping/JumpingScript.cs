using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingScript : MonoBehaviour
{
    private const KeyCode Space = KeyCode.Space;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetButtonDown(Space))
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        }
       
    }
}
