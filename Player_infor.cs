using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInformation : MonoBehaviour
{
	public string Name { get; set; }
	public string Score { get; set; }
	public PlayerInformation()
	{
	}
	public PlayerInformation(string name, string score)
	{
		this.Name = name;
		this.Score = score;
	}
}
