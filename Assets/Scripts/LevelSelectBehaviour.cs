using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelectBehaviour : MonoBehaviour
{ 
    public GameObject[] levelPanels;

    // Start is called before the first frame update
    public void backToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void showLevelPanel(int levelNum)
    {
        levelPanels[levelNum].SetActive(true);
    }

    public void startLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("SelectedLevelIndex", levelIndex);
        SceneManager.LoadScene("CharacterSelection");
    }

    public void closePanel(int levelNum)
    {
        levelPanels[levelNum].SetActive(false);
    }

    public void tutorialOn()
    {
        PlayerPrefs.SetInt("Tutorial", 1);
        Debug.Log(PlayerPrefs.GetInt("Tutorial"));
    }
    
    public void tutorialOff()
    {
        PlayerPrefs.SetInt("Tutorial", 0);
        Debug.Log(PlayerPrefs.GetInt("Tutorial"));
    }

    
}
