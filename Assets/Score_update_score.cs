using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Score_update_score : MonoBehaviour
{
    public TMP_Text scoreBoard;
    public string filepath = "high_score";
    public ArrayList score_list = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.text = "";
        score_update();
    }

    // Update is called once per frame
    public void score_update()
    {
        try
        {
            if (System.IO.File.Exists(filepath + ".txt"))
            {
                using (StreamReader reader = new StreamReader(filepath + ".txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(" - ");
                        Player_Information player = new Player_Information(line[0], line[1]);
                        score_list.Add(player);
                    }
                }
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filepath + ".txt"))
                {
                    for (int i = 0; i < 10; i++)
                    {
                        writer.WriteLine("Player - 0");
                    }
                }
                using (StreamReader reader = new StreamReader(filepath + ".txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(" - ");
                        Player_Information player = new Player_Information(line[0], line[1]);
                        score_list.Add(player);
                    }
                }
            }

        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        scoreBoard.text = "";
        foreach (Player_Information temp in score_list)
        {
            scoreBoard.text += temp.Score + "\n";
        }
    }
}
