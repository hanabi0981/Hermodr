using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private GameObject done, need;

    private int isQuestProgress = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isQuestProgress = PlayerPrefs.GetInt("isQuest");

        if (isQuestProgress == 1)
        {
            if (PlayerPrefs.GetInt("isBattle") ==1)
            {
                done.SetActive(true);
                need.SetActive(false);
            }

            if(PlayerPrefs.GetInt("killCount") > 0)
            {
                done.SetActive(true);
                need.SetActive(false);
            }
        }
    }
}
