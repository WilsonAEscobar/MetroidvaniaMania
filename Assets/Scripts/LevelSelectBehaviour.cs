using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectBehaviour : MonoBehaviour
{ 
    public GameObject[] levelPanels;

    // Start is called before the first frame update
    public void showLevelPanel(int levelNum)
    {
        levelPanels[levelNum].SetActive(true);
    }

    
}
