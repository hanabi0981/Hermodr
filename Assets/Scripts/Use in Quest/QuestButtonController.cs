using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestButtonController : MonoBehaviour
{
    private int isQuest=0;
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
    }

    public void QuestCancle()
    {
        PlayerPrefs.SetInt("isQuest", 0);
    }
}
