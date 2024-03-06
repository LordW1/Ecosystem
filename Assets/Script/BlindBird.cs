using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blindbird : MonoBehaviour
{
    private float speed = 3f; 
    private float switchDirectionTime = 6f; 
    private float timer;
    private float facing = 1;
    private float jumpForce = 5f;
    private bool IsGrounded;
    private Rigidbody2D rb;
    private bool eaten = false;

    private void Start()
    {
        timer = switchDirectionTime;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        Walk();
        CheckForGoldBugs();
    }

    private void Walk()
    {
        if (eaten){
            speed = 5;
            transform.Translate(Vector3.right * speed * Time.deltaTime * facing);
            
        } else

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
        }
    }

    private void Jump()
    {
        if (IsGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            IsGrounded = false; 
        }
    }

    private void CheckForGoldBugs()
    {
        // Check if there are nearby game objects named "goldbugs"
        GameObject[] goldBugs = GameObject.FindGameObjectsWithTag("goldbugs");

        foreach (GameObject goldBug in goldBugs)
        {
            float distance = Vector3.Distance(transform.position, goldBug.transform.position);

            // If a goldbug is nearby, trigger a jump
            if (distance < 5f)
            {
                Jump();

                  if (!IsGrounded)
                {
                    HandleGoldBugCollision(goldBug);
                }
            }
        }
    }


     private void HandleGoldBugCollision(GameObject goldBug)
    {
        // Destroy the goldbug
        Destroy(goldBug);

        // Create a new blindbird game object
        Instantiate(gameObject, new Vector3(-5, 0, 0), Quaternion.identity);

        eaten = true;
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsGrounded = true;
        }
    }
}