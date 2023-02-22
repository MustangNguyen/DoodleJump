using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Springs_Animation : MonoBehaviour
{
    public GameObject springs;
    float vertical;
    Doodle_Movement dm;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        dm = player.GetComponent<Doodle_Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixUpdate()
    {
        vertical = Input.GetAxisRaw("Vertical");
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && dm.lastMoveDirection.y < 0)
        {
            springs.GetComponent<Animator>().SetTrigger("SpringsToRoll");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            springs.GetComponent<Animator>().SetTrigger("SpringsToIdle");
        }
    }
}
