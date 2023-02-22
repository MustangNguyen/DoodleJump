using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Buffer_Animation : MonoBehaviour
{
    public GameObject jumpBuffer;
    float vertical=0;
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
            jumpBuffer.GetComponent<Animator>().SetTrigger("OnJumpTrigger");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jumpBuffer.GetComponent<Animator>().SetTrigger("OnJumpExitTrigger");
        }
    }
}
