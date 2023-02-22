using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text textScore;
    float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score < player.position.y)
        {
            score = player.position.y;
        }
        int displayScore = Convert.ToInt32(score * 10);
        PlayerPrefs.SetInt("HighScore", displayScore);
        textScore.text = displayScore.ToString("0");
    }
}
