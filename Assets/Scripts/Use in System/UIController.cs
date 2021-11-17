using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject popup_window;
    public Text questTitle, questDescription1, questDescription2, questDescription3;

    public void Popup_window()
    {
        popup_window.SetActive(true);

        if (PlayerPrefs.GetInt("isQuest") == 1)
        {
            questTitle.text = PlayerPrefs.GetString("questTitle");
            questDescription1.text = PlayerPrefs.GetString("questDescription1");
            questDescription2.text = PlayerPrefs.GetString("questDescription2");
            questDescription3.text = PlayerPrefs.GetString("questDescription3"); ;
        }
        else
        {
            questTitle.text = "";
            questDescription1.text = "";
            questDescription2.text = "";
            questDescription3.text = "";

        }
    }

    public void Close_window()
    {
        popup_window.SetActive(false);
    }
}
