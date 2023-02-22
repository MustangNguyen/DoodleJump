using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodle_Position : MonoBehaviour
{
    public float width = 9f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > width)
        {
            transform.position = new Vector3(transform.position.x - 2 * width, transform.position.y, transform.position.z);
        }
        if(transform.position.x < -width)
        {
            transform.position = new Vector3(transform.position.x + 2 * width, transform.position.y, transform.position.z);
        }
    }
}
