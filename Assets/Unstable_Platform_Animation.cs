using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unstable_Platform_Animation : MonoBehaviour
{
    Animator animator;
    public Transform cam;
    public GameObject UP;
    GameObject player;
    Doodle_Movement dm;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        dm = player.GetComponent<Doodle_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        Transform up = gameObject.GetComponent<Transform>();
        if (up.position.y < (cam.position.y - 14f))
        {
            Destroy(UP);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player")&&dm.lastMoveDirection.y<0)
        {
            animator.SetTrigger("Broke_Trigger");
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 3f;
            }
        }
    }
    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.tag == "Player")
    //    {
    //        animator.SetTrigger("Broke_Trigger");
    //        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    //        if(rb != null)
    //        {
    //            rb.gravityScale =  3f;
    //        }
    //    }
    //}
    //void OnTriggerExit2D(Collider2D collider)
    //{
    //    if (collider.gameObject.CompareTag("Player")){
    //        animator.SetTrigger("Falling");
    //    }
    //}
}
