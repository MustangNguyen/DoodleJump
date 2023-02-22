using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class JetpackAnimator : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Doodle");
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.y > 20f && rb.gravityScale < 0)
            animator.SetTrigger("Flying");
        else if (rb.velocity.y < 10f && rb.gravityScale > 0)
            animator.SetTrigger("Finishing");
    }
}
