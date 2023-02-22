using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFallObject : MonoBehaviour
{
    GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (gameObject.transform.position.y < (cam.transform.position.y - 13f))
        {
            Destroy(gameObject);
        }
    }
}
