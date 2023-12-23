using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Information
{
    public string Name { get; set; }
    public string Score { get; set; }
    public Player_Information()
    {
        
    }
    public Player_Information(string name, string score)
    {
        this.Name = name;
        this.Score = score;
    }
}
