using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float laneDistance = 3f;
    public float jumpForce = 5f;

    private int currentLane = 1;
    private bool isGrounded = true;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
            currentLane--;

        if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
            currentLane++;

        Vector3 targetPosition = transform.position;
        targetPosition.x = (currentLane - 1) * laneDistance;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}

