using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScoreData : MonoBehaviour
{
    public string Username { get; private set; }
    public int HighScore { get; private set; }

    public PlayerScoreData(string username, int highScore)
    {
        Username = username;
        HighScore = highScore;
    }
}
