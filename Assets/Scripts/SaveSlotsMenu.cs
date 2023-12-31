using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSlotsMenu : MonoBehaviour
{
    public GameObject[] newGameButtons = new GameObject[3];
    public GameObject[] loadGameButtons = new GameObject[3];

    public int[] saveIds = new int[3];
    // Start is called before the first frame update
    public void setSaveID(int saveID)
    {
        SaveID.saveID = saveID;
        PlayerPrefs.SetInt("SlotSaved" + SaveID.saveID, 1);
    }
    
    public void loadGame(int saveIDSlot)
    {
        setSaveID(saveIDSlot);
        SceneManager.LoadScene("MainMenu");
        Debug.Log("This is the current SaveID: " + SaveID.saveID);
    }

    public void Update()
    {
        //save slot 1
        if(PlayerPrefs.GetInt("SlotSaved" + saveIds[0]) == 1)
        {
            loadGameButtons[0].SetActive(true);
            newGameButtons[0].SetActive(false);
        }
        else
        {
            loadGameButtons[0].SetActive(false);
            newGameButtons[0].SetActive(true);
        }

        //save slot 2
        if (PlayerPrefs.GetInt("SlotSaved" + saveIds[1]) == 1)
        {
            loadGameButtons[1].SetActive(true);
            newGameButtons[1].SetActive(false);
        }
        else
        {
            loadGameButtons[1].SetActive(false);
            newGameButtons[1].SetActive(true);
        }

        //save slot 3
        if (PlayerPrefs.GetInt("SlotSaved" + saveIds[2]) == 1)
        {
            loadGameButtons[2].SetActive(true);
            newGameButtons[2].SetActive(false);
        }
        else
        {
            loadGameButtons[2].SetActive(false);
            newGameButtons[2].SetActive(true);
        }
    }

    public void ClearSave(int saveID)
    {
        DatabaseManager databaseManagerInstance = DatabaseManager.Instance;
        databaseManagerInstance.DeletePlayerAndScores(PlayerPrefs.GetString("SaveSlotUsername" + saveID));

        PlayerPrefs.DeleteKey("SlotSaved" + saveID);
        PlayerPrefs.DeleteKey("SaveSlotUsername" + saveID);
        PlayerPrefs.DeleteKey("CurrentTime" + saveID);
        for (int levelID = 0; levelID < 5; levelID++)
        {
            string highScoreKey = $"HighScore_SaveID_{saveID}_LevelID_{levelID}";
            SaveManager.SetHighScore(saveID, levelID, 0);
            PlayerPrefs.DeleteKey(highScoreKey);
        }
    }

}
