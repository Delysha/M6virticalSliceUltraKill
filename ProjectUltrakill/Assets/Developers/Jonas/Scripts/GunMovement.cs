using UnityEngine;

public class GunMovement : MonoBehaviour
{
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script
    public float smoothing = 5f;

    void Update()
    {
        // Get the player's movement input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate the target direction based on player input
        Vector3 targetDirection = playerMovement.transform.forward * z + playerMovement.transform.right * x;

        // Smoothly rotate the gun towards the target direction
        Quaternion newRotation = Quaternion.LookRotation(targetDirection, playerMovement.transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, smoothing * Time.deltaTime);
    }
}
