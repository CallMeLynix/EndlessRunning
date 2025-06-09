using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float laneDistance = 3f;
    public float sideSpeed = 10f;

    private float timeElapsed = 0f;
    public float speedIncreaseInterval = 5f;
    public float speedIncrement = 0.5f;

    private int currentLane = 1;
    private Rigidbody rb;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= speedIncreaseInterval)
        {
            timeElapsed = 0f;
            forwardSpeed += speedIncrement;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++;
        }
    }

    void FixedUpdate()
    {

        Vector3 velocity = rb.velocity;
        velocity.z = forwardSpeed;
        rb.velocity = velocity;
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