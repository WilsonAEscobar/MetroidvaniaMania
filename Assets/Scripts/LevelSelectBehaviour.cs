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
    
    

    
}
