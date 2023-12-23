using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class DieNumber : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
