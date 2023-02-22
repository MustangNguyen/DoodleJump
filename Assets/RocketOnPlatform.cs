using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketOnPlatform : MonoBehaviour
{
    GameObject createRocket;
    public GameObject doodle;
    public GameObject jetpack;
    Doodle_Movement dm;
    private void Start()
    {
        dm = doodle.GetComponent<Doodle_Movement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&&dm.lastMoveDirection.y < 0)
        {
            createRocket=Instantiate(jetpack,doodle.transform);
            //createRocket.transform.parent = doodle.transform;
            createRocket.transform.localScale = new Vector3(0.6f, 0.6f, 0.6f);
            createRocket.transform.localPosition = new Vector3(0.225f, -0.225f, 0);
            //Debug.Log("done");
        }
    }
}
