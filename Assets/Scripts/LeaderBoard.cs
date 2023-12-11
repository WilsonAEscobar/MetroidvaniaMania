using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoard : MonoBehaviour
{
    public TextMeshProUGUI[] usernameTexts;
    public TextMeshProUGUI[] scoreTexts;

    void Start()
    {
        //Will get the list for level one - just gotta change the value at the end
        List<PlayerScoreData> topScores = DatabaseManager.Instance.GetTopScoresForLevel(1);

        for (int i = 0; i < topScores.Count; i++)
        {
            usernameTexts[i].text = topScores[i].Username;
            scoreTexts[i].text = topScores[i].HighScore.ToString();
        }
    }
}
