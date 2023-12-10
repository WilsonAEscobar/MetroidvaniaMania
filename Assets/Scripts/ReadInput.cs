using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ReadInput : MonoBehaviour
{
    static string input;
    public TMP_InputField usernameField;
    public TextMeshProUGUI usernameFixed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.HasKey("SaveSlotUsername" + SaveID.saveID))
        {
            usernameField.gameObject.SetActive(false);
            usernameFixed.gameObject.SetActive(true);
            usernameFixed.text = "Username: "+ PlayerPrefs.GetString("SaveSlotUsername"+SaveID.saveID);
            
        }
        else
        {
            usernameField.gameObject.SetActive(true);
            usernameFixed.text = "";
            usernameFixed.gameObject.SetActive(false);
            input = string.Empty;
        }
        
    }

    public void ReadStringInput(string s)
    {
        s = usernameField.text;
        input = s;
        Debug.Log("Setting PlayerPrefs value: " + input);
        PlayerPrefs.SetString("SaveSlotUsername"+SaveID.saveID, input);
    }

    public void goHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
