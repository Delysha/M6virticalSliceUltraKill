using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMove : MonoBehaviour
{
    public PlayerMovement playerMovement; // Reference to the PlayerMovement script
    public float uiMoveSpeed = 1f;

    private void Update()
    {
        if (playerMovement != null)
        {
            // Assuming you want to move the UI in the player's movement direction
            Vector3 playerVelocity = playerMovement.velocity;

            // You can modify this based on how you want to apply the velocity to the UI
            Vector3 uiMoveDirection = new Vector3(playerVelocity.x, 0, playerVelocity.z);

            // Move the UI based on the player's velocity
            transform.Translate(uiMoveDirection * uiMoveSpeed * Time.deltaTime);
        }
    }
}
