using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Doodle_Movement : MonoBehaviour
{
    Rigidbody2D rb;
    public float movementSpeed = 25f;
    public float movement = 0f;
    public bool d_FacingLeft = true;
    float inputHorizontal;
    Vector3 previousPosition;
    public Vector3 lastMoveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        previousPosition = transform.position;
        lastMoveDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        //Debug.Log(Input.GetAxis("Vertical"));
        movement = Input.GetAxis("Horizontal") * movementSpeed;
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal < 0f && !d_FacingLeft)
            Flip();
        else if (inputHorizontal > 0f && d_FacingLeft)
            Flip();

        if (transform.position != previousPosition)
        {
            lastMoveDirection = (transform.position - previousPosition).normalized;
            previousPosition = transform.position;
        }
    }
    void Flip()
    {
        d_FacingLeft = !d_FacingLeft;
        Vector3 theFlip = transform.localScale;
        theFlip.x *= -1f;
        transform.localScale = theFlip;
    }
}
