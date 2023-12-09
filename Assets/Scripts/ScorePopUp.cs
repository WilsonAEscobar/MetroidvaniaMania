using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScorePopUp : MonoBehaviour
{
    public GameObject scoreDisplayCanvas;
    // Start is called before the first frame update
    public void DisplayScore(int score, TextMeshProUGUI scoreText)
    {
        // Update the score text with the provided score
        scoreText.text = "Score: " + score;
    }
    public void AcknowledgePopup()
    {
        scoreDisplayCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f; // Unfreeze the level
        SceneManager.LoadScene("LevelSelection");

        Debug.Log("Acknowledged the score popup");
    }
}
