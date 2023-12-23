using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.IO;
using System;
using Unity.VisualScripting.FullSerializer;

public class Saving_Score : MonoBehaviour
{
    public TMP_Text scoreBoard_name;
    public TMP_Text scoreBoard_score;
    public TMP_InputField inputName;
    public GameObject score;
    public GameObject button;
    public string file_path = "high_score";
    public ArrayList score_list = new ArrayList();
    // Code nút lưu điểm ở đây
    public void Submit_Score()
    {
        ArrayList top_player = new ArrayList();
        int index = 0;
        string player_name = inputName.text;
        string player_score = score.GetComponent<Text>().text;
        Player_Information playerInfor;

        if (player_name == null || player_name == "")
        {
            player_name = "UNKNOWN ALIEN";
            playerInfor = new Player_Information(player_name, player_score);
        }
        else
        {
            playerInfor = new Player_Information(player_name, player_score);
        }

        try
        {
            using (StreamReader reader = new StreamReader(file_path + ".txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(" - ");
                    Player_Information player = new Player_Information(line[0], line[1]);
                    top_player.Add(player);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        if (top_player.Count >= 10)
        {
            foreach (Player_Information temp in top_player)
            {
                if (Convert.ToInt32(player_score) >= Convert.ToInt32(temp.Score))
                {
                    top_player.Insert(index, playerInfor);
                    top_player.RemoveAt(10);
                    break;
                }
                index++;

            }
        }
        else
        {
            top_player.Add(playerInfor);
        }
        try
        {
            using (StreamWriter writer = new StreamWriter(file_path + ".txt"))
            {
                ;
                foreach (Player_Information temp in top_player)
                {
                    writer.WriteLine(temp.Name + " - " + temp.Score);
                }
            }
            score_update_name();
            score_update_score();
            top_player = null;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
        Destroy(button);
    }
    //hết code nút lưu điểm
    public void score_update_name()
    {
        score_list.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(file_path + ".txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(" - ");
                    Player_Information player = new Player_Information(line[0], line[1]);
                    score_list.Add(player);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        scoreBoard_name.text = "";
        foreach (Player_Information temp in score_list)
        {
            scoreBoard_name.text += temp.Name + "\n";
        }
    }

    public void score_update_score()
    {
        score_list.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(file_path + ".txt"))
            {
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(" - ");
                    Player_Information player = new Player_Information(line[0], line[1]);
                    score_list.Add(player);
                }
            }
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        scoreBoard_score.text = "";
        foreach (Player_Information temp in score_list)
        {
            scoreBoard_score.text += temp.Score + "\n";
        }

    }

}
