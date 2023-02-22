using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackBehavior : MonoBehaviour
{
    public float GravityScale=5f;
    private bool isAttach = true;
    private Transform parentTransform;
    GameObject doodle;
    Rigidbody2D rb;
    float rotatez;
    // Start is called before the first frame update
    void Start()
    {
        //parentTransform = transform.parent;
        doodle = GameObject.Find("Doodle");
        rb=doodle.GetComponent<Rigidbody2D>();
        rb.gravityScale = -3;
        StartCoroutine(WaitForFunction());
    }

    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(2);
        rb.gravityScale = 3;
    }

    void FixedUpdate()
    {
        if (!isAttach)
        {
            transform.Rotate(0, 0, rotatez);
            //transform.position = transform.position + new Vector3(0, -0.005f, 0);
        }
        //parentTransform.gameObject.GetComponent<Rigidbody2D>();

        //Debug.Log(velocity.magnitude);
        if (rb.velocity.y < 1f && rb.velocity.y > -1f && transform.parent != null) 
        {
            isAttach = false;
            transform.SetParent(null);
            Rigidbody2D rb2 = GetComponent<Rigidbody2D>();
            rb2.gravityScale = GravityScale;
            rb2.simulated = true;
            Vector2 velocity2 = rb2.velocity;
            velocity2.y = 5;
            if(doodle.GetComponent<Doodle_Movement>().d_FacingLeft==true)
                velocity2.x = Random.Range(1, 5);
            else
                velocity2.x = Random.Range(-5, -1);
            if (velocity2.x >= 0)
                rotatez = -0.5f;
            else
                rotatez = 0.5f;
            rb2.velocity = velocity2;
        }       
    }
}
