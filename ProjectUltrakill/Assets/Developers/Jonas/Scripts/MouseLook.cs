using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

    public float camTilt = 5f;
    [SerializeField] private float prevTilt = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Camera tilt
        float horizontalInput = Input.GetAxis("Horizontal");
        float tilt = Mathf.Lerp(prevTilt, horizontalInput * camTilt, Time.deltaTime * 20);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, -tilt);
        playerBody.Rotate(Vector3.up * mouseX);

        prevTilt = tilt;
    }
}
