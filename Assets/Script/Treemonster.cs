using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treemonster : MonoBehaviour
{
    private bool eaten = false;
    private float timer = 5f;
    public GameObject goldBugPrefab; 

    private void Update()
    {
        if (eaten == true)
        {
            SpawnGoldBugs();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object is a BlindBird
        if (collision.gameObject.CompareTag("BlindBird"))
        {
            // Destroy the BlindBird
            Destroy(collision.gameObject);

            eaten = true;
            
        }
    }

    void SpawnGoldBugs()
    {
        Vector3 spawnPosition = transform.position;

        // Instantiate two GoldBug GameObjects at the top position of the Treemonster
        GameObject goldBug1 = Instantiate(goldBugPrefab, new Vector3(11, 3, 61), Quaternion.identity); //new Vector3(spawnPosition.x - 1, spawnPosition.y + 2, spawnPosition.z), Quaternion.identity);
        GameObject goldBug2 = Instantiate(goldBugPrefab, new Vector3(11, 3, 61), Quaternion.identity); //new Vector3(spawnPosition.x + 1, spawnPosition.y + 2, spawnPosition.z), Quaternion.identity);

        eaten = false;
    }
    
}