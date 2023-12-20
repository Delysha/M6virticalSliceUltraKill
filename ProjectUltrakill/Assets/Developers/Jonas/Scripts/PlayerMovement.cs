using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Basic properties")]
    public float speed = 12;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [Header("Dash properties")]
    public float dashTime;
    public float dashSpeed;
    public float dashDecelerationAir;
    public float dashDecelerationGround;
    public float dashIncreaseRate;
    private Vector3 dashDirection;
    public TMP_Text dashText;

    [Header("Ground properties")]
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public Vector3 velocity;
    float dashCooldown;
    public bool isDashing;

    void Update()
    {
        //temporary dash text
        dashText.text = ((int)dashCooldown).ToString();
        if (dashCooldown <= 3)
            dashCooldown += dashIncreaseRate * Time.deltaTime;

        //checking if the player is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        //ground slam
        if (!isGrounded && Input.GetKeyDown("left ctrl"))
        {
            velocity.y = -40f;
        }

        //basic movement and jumping
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //if grounded make sure it doesnt apply gravity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //dashing
        if (Input.GetKeyDown("left shift"))
        {
            if (!isDashing && dashCooldown >= 1f)
            {
                isDashing = true;
                StartCoroutine(DashCoroutine());
            }
        }

        //stops gravity being applied to you during dash
        if (!isDashing)
        {
            velocity.y += gravity * Time.deltaTime;
        }

        //faking momentum after dash lmao
        if (isGrounded)
        {
            velocity.x = Mathf.Lerp(velocity.x, 0f, dashDecelerationGround * Time.deltaTime);
            velocity.z = Mathf.Lerp(velocity.z, 0f, dashDecelerationGround * Time.deltaTime);
        }
        else
        {
            velocity.x = Mathf.Lerp(velocity.x, 0f, dashDecelerationAir * Time.deltaTime);
            velocity.z = Mathf.Lerp(velocity.z, 0f, dashDecelerationAir * Time.deltaTime);
        }

        controller.Move(velocity * Time.deltaTime);
    }

    private IEnumerator DashCoroutine()
    {
        dashDirection = (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical")).normalized;

        dashCooldown -= 1f;

        if (dashDirection == Vector3.zero)
            dashDirection = transform.forward;

        float startTime = Time.time;
        while (Time.time < startTime + dashTime)
        {
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
            velocity.y = 0;

            yield return null;
        }

        isDashing = false;
        velocity = dashDirection * (dashSpeed - 1.5f);
    }
}
