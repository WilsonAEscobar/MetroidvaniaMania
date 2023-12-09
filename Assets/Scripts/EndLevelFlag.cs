using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class EndLevelFlag : MonoBehaviour
{
    public GameObject scoreDisplayCanvas;
    public TextMeshProUGUI scoreText;
    public int currentScore;

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f; // Freeze the level

        // Access the LevelLogic script to get the player's score
        LevelLogic levelLogic = FindObjectOfType<LevelLogic>();
        scoreDisplayCanvas.gameObject.SetActive(true);
        if (other.CompareTag("Player"))
        {
            levelLogic.calculateScore();
            currentScore = levelLogic.score;
            
            ScorePopUp popupScript = FindObjectOfType<ScorePopUp>();
            if (popupScript != null)
            {
                popupScript.DisplayScore(currentScore, scoreText);
            }
            
           
      
            
        }
    }
}
