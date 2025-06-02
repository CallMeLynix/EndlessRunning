using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float laneDistance = 3f; // Jarak antar jalur
    public float jumpForce = 5f;
    public float sideSpeed = 10f;

    private int currentLane = 1;
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Input pindah jalur
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
        }

        // Input lompat
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // Gerakan maju
        Vector3 velocity = rb.velocity;
        velocity.z = forwardSpeed;
        rb.velocity = velocity;

        // Geser ke jalur target
        float targetX = (currentLane - 1) * laneDistance;
        float deltaX = targetX - transform.position.x;
        Vector3 move = new Vector3(deltaX * sideSpeed, rb.velocity.y, forwardSpeed);
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
