using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    GameObject doodle;
    Doodle_Movement dm;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        doodle = GameObject.Find("Doodle");
        dm = doodle.GetComponent<Doodle_Movement>();
        rb = doodle.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && dm.lastMoveDirection.y < 0)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = 10;
            rb.velocity = velocity;
            // Add logic for what should happen when the player collides with the Collectible object
            Destroy(gameObject);
            
        }
    }
}
