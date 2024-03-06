using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GoldBug : MonoBehaviour
{
    private float speed = 6f;
    private float switchDirectionTime = 6f;
    private float timer;
    private float facing = 1;
    private float jumpForce = 5f;
    private bool IsGrounded;
    private Rigidbody2D rb;
    private float Getdown = 0;

    private void Start()
    {
        timer = switchDirectionTime;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        Fly();

        if (Getdown == 2)
        {
            flydown();
        }
    }

    private void Fly()
    {
        if (timer <= 3f)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime * facing);
        }
        else if (timer > 3f)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime * facing);
        }

        if (timer <= 0f)
        {
            timer = switchDirectionTime;
            Getdown++;
        }
    }

    private void flydown()
    {
        // Adjust the downward movement speed as needed
        float downwardSpeed = -2f;

        // Move left or right while flying down
        transform.Translate(Vector3.left * speed * Time.deltaTime * facing);

        // Move vertically down using Rigidbody2D
        rb.velocity = new Vector2(rb.velocity.x, downwardSpeed);

        // Optional: Rotate the object while flying down
        // transform.Rotate(Vector3.forward * Time.deltaTime * 50f);
    }
}