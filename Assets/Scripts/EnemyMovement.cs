using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveDistance = 2f;
    public float moveSpeed = 2f;
    private Vector3 startPos;
    private bool movingForward = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float movement = moveSpeed * Time.deltaTime;

        if (movingForward)
        {
            transform.Translate(Vector3.forward * movement);

            if (Vector3.Distance(transform.position, startPos) >= moveDistance)
                movingForward = false;
        }
        else
        {
            transform.Translate(Vector3.back * movement);

            if (Vector3.Distance(transform.position, startPos) >= moveDistance)
                movingForward = true;
        }
    }
}

