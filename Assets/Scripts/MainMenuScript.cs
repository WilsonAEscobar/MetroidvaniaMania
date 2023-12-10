using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadLevelSelection()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    
    public void loadSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void goSaveSlots()
    {
        SceneManager.LoadScene("SaveSlots");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
