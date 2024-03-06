using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Treemonster : MonoBehaviour
{
    private bool eaten = false;
    private float timer = 5f;

    private void Start()
    {

    }

    private void Update()
    {
        if (eaten)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                SpawnGoldbugs();
                eaten = false;
                timer = 5f; // Reset the timer
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BlindBird"))
        {
            // Check if the BlindBird is currently jumping
            Blindbird blindbirdScript = other.GetComponent<Blindbird>();
            if (blindbirdScript != null)
            {
                // Destroy the BlindBird that collided with Treemonster
                Destroy(other.gameObject);
                eaten = true;
            }
        }
    }

    private void SpawnGoldbugs()
    {
        // Spawn two Goldbug game objects
        Instantiate(Resources.Load("GoldBugPrefab"), transform.position + new Vector3(-1, 0, 0), Quaternion.identity);
        Instantiate(Resources.Load("GoldBugPrefab"), transform.position + new Vector3(1, 0, 0), Quaternion.identity);
    }
}

  
