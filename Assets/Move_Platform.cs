using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Platform : MonoBehaviour 
{ 
    public float speed = 10f;
    public bool direction=false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (direction) 
        { 
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            if (transform.position.x<=-7)
                direction = false;
        }
        else if (!direction)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            if (transform.position.x >= 7)
                direction = true;
        }
    }
}
