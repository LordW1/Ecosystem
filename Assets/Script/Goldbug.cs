using System.Collections;
using UnityEngine;

public class GoldBug : MonoBehaviour
{
    private enum BugState
    {
        FlyMore,
        Flying,
        GetDown
    }

    private BugState currentState = BugState.FlyMore;

    private float speed = 6f;
    private float switchDirectionTime = 6f;
    private float timer;
    private float facing = 1;
    private float jumpForce = 5f;
    private bool IsGrounded;
    private Rigidbody2D rb;
    private float Getdown = 0;
    private bool normal = false;

    private void Start()
    {
        timer = switchDirectionTime;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        switch (currentState)
        {
            case BugState.FlyMore:
                FlyMore();
                if (normal == true)
                {
                    currentState = BugState.Flying;
                }
                break;

            case BugState.Flying:
                Fly();
                speed = 6f;
                if (Getdown == 1)
                {
                    currentState = BugState.GetDown;
                }
                break;

            case BugState.GetDown:
                flydown();
                break;
        }
    }

    private void FlyMore()
    {

        if (timer > 5f)
        {
            speed = 10f;
            transform.Translate(Vector3.left * speed * Time.deltaTime * facing);

        } else 
        
        if (timer <= 5f)
        {
            normal = true;
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

        float downwardSpeed = -2f;


        transform.Translate(Vector3.left * speed * Time.deltaTime * facing);


        rb.velocity = new Vector2(rb.velocity.x, downwardSpeed);

    }
}

/*using System.Collections;
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

        float downwardSpeed = -2f;


        transform.Translate(Vector3.left * speed * Time.deltaTime * facing);


        rb.velocity = new Vector2(rb.velocity.x, downwardSpeed);


        // transform.Rotate(Vector3.forward * Time.deltaTime * 50f);
    }
}*/