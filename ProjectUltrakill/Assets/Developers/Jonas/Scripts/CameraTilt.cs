using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTilt : MonoBehaviour
{
    public float tiltSpeed = 5f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float tiltAngle = horizontalInput * tiltSpeed;

        transform.rotation = Quaternion.Euler(0f, 0f, -tiltAngle);
    }
}