using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class On_dead : MonoBehaviour
{
    public Transform cam;
    public Transform player;
    GameObject gameplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < (cam.transform.position.y-20f))
        {
            //Scene currentScene = SceneManager.GetActiveScene();
            //SceneManager.LoadScene(currentScene.name);
            SceneManager.LoadScene("YouDie");
        }

    }
    void FixUpdate()
    {

    }
}
