using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButtonController : MonoBehaviour
{
    private int isQuest = 0;
    public GameObject buttonCancle;
    public GameObject buttonStart;

    // Start is called before the first frame update
    void Start()
    {
        isQuest = PlayerPrefs.GetInt("isQuest");
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("isQuest") == 0)
        {
            buttonStart.SetActive(true);
            buttonCancle.SetActive(false);
        }
        else
        {
            buttonStart.SetActive(false);
            buttonCancle.SetActive(true);
        }

    }

    public void QuestStart()
    {
        PlayerPrefs.SetInt("isQuest", 1);
        PlayerPrefs.SetInt("progressQuest", PlayerPrefs.GetInt("selectedQuest"));

    }

    public void QuestCancle()
    {
        PlayerPrefs.SetInt("isQuest", 0);
        PlayerPrefs.SetInt("progressQuest", 0);
        PlayerPrefs.SetInt("selectedQuest", 0);

        PlayerPrefs.SetString("questTitle", "");
        PlayerPrefs.SetString("questDescription1", "");
        PlayerPrefs.SetString("questDescription2", "");
        PlayerPrefs.SetString("questDescription3", "");

        this.gameObject.GetComponentInChildren<UIController>().questTitle.text = " ";
        this.gameObject.GetComponentInChildren<UIController>().questDescription1.text = " ";
        this.gameObject.GetComponentInChildren<UIController>().questDescription2.text = " ";
        this.gameObject.GetComponentInChildren<UIController>().questDescription3.text = " ";



    }

}
