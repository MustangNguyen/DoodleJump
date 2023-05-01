using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Propertile : MonoBehaviour
{
    public Transform cam;
    public float jumpForce = 40f;
    public bool move = false;
    public float speed = 5f;
    bool direction = false;
    void Update()
    {
        if (move)
        {
            if (direction)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
                if (transform.position.x <= -7)
                    direction = false;
            }
            else if (!direction)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (transform.position.x >= 7)
                    direction = true;
            }
        }
        if (gameObject.transform.position.y < (cam.position.y - 13f))
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null && collision.collider.tag == "Player")
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
            else if (rb != null && collision.collider.tag == "Monster")
            {
                Vector2 velocity = rb.velocity;
                velocity.y = 5f;
                rb.velocity = velocity;
            }
        }
    }
}
