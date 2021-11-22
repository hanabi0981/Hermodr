using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] questDone = new GameObject[3];
    [SerializeField]
    private GameObject[] questNeed = new GameObject[3];

    private int progressQuest;

    // Start is called before the first frame update
    void Start()
    {
        progressQuest = PlayerPrefs.GetInt("isQuest");
    }

    // Update is called once per frame
    void Update()
    {
        progressQuest = PlayerPrefs.GetInt("progressQuest");

        // 선택된 퀘스트가 없을 때
        if (progressQuest == 0)
        {
            foreach (GameObject gameObject in questDone)
                gameObject.SetActive(false);

            foreach (GameObject gameObject in questNeed)
                gameObject.SetActive(false);
        }
        // 첫 번째 퀘스트 선택
        else if (progressQuest == 1)
        {
            // 퀘스트의 첫 번째 조건 검사
            if (PlayerPrefs.GetInt("isForestClear") >= 1)
                Done(0);
            else
                Need(0);

            // 퀘스트의 두 번째 조건 검사
            if (PlayerPrefs.GetInt("isWolfKillCount") >= 5)
                Done(1);
            else
                Need(1);

            // 퀘스트의 세 번째 조건 검사
            if (PlayerPrefs.GetInt("isWolfKillCount") >= 10)
                Done(2);
            else
                Need(2);
        }
        // 두 번째 퀘스트 선택
        else if (progressQuest == 2)
        {
            // 퀘스트의 첫 번째 조건 검사
            if (PlayerPrefs.GetInt("isHaveThor") == 1)
                Done(0);
            else
                Need(0);

            // 퀘스트의 두 번째 조건 검사
            if (PlayerPrefs.GetInt("isSwampClear") >= 1)
                Done(1);
            else
                Need(1);

            // 퀘스트의 세 번째 조건 검사
            if (PlayerPrefs.GetInt("isShellKillCount") >= 10)
                Done(2);
            else
                Need(2);

        }
        // 세 번째 퀘스트 선택
        else if (progressQuest == 3)
        {
            // 퀘스트의 첫 번째 조건 검사
            if (PlayerPrefs.GetInt("isHaveBaldur") == 1)
                Done(0);
            else
                Need(0);

            // 퀘스트의 두 번째 조건 검사
            if (PlayerPrefs.GetInt("isHellClear") >= 1)
                Done(1);
            else
                Need(1);

            // 퀘스트의 세 번째 조건 검사
            if (PlayerPrefs.GetInt("isGiantKillCount") >= 10)
                Done(2);
            else
                Need(2);
        }
        // 네 번째 퀘스트 선택
        else if (progressQuest == 4)
        {
            // 퀘스트의 첫 번째 조건 검사
            if (PlayerPrefs.GetInt("isForestClear") >= 1 && PlayerPrefs.GetInt("isSwampClear") >= 1 && PlayerPrefs.GetInt("isHelltClear") >= 1 && PlayerPrefs.GetInt("isDuskClear") >= 1)
                Done(0);
            else
                Need(0);

            // 퀘스트의 두 번째 조건 검사
            if (PlayerPrefs.GetInt("isDuskKillCount") >= 10)
                Done(1);
            else
                Need(1);

            // 퀘스트의 세 번째 조건 검사
            if (PlayerPrefs.GetInt("isTotalKillCount") >= 100)
                Done(2);
            else
                Need(2);
        }
        // 다섯 번째 퀘스트 선택
        else if (progressQuest == 5)
        {
            // 퀘스트의 첫 번째 조건 검사
            if (PlayerPrefs.GetInt("isForestClear") >= 4 && PlayerPrefs.GetInt("isSwampClear") >= 4 && PlayerPrefs.GetInt("isHelltClear") >= 4 && PlayerPrefs.GetInt("isDuskClear") >= 4)
                Done(0);
            else
                Need(0);

            // 퀘스트의 두 번째 조건 검사
            if (PlayerPrefs.GetInt("isCompleteGods") == 1)
                Done(1);
            else
                Need(1);

            // 퀘스트의 세 번째 조건 검사
            if (PlayerPrefs.GetInt("isLokiKillCount") >= 1)
                Done(2);
            else
                Need(2);
        }
        // 여섯 번째 퀘스트 선택
        else if (progressQuest == 6)
        {
            // 퀘스트의 첫 번째 조건 검사
            if (PlayerPrefs.GetInt("isForestFailed") >= 1)
                Done(0);
            else
                Need(0);

            // 퀘스트의 두 번째 조건 검사
            if (PlayerPrefs.GetInt("isSwampFailed") >= 1)
                Done(1);
            else
                Need(1);

            // 퀘스트의 세 번째 조건 검사
            if (PlayerPrefs.GetInt("isHellFailed") >= 1)
                Done(2);
            else
                Need(2);
        }
    }

    void Done(int doneNum)
    {
        questDone[doneNum].SetActive(true);
        questNeed[doneNum].SetActive(false);
    }

    void Need(int needNum)
    {
        questNeed[needNum].SetActive(true);
        questDone[needNum].SetActive(false);
    }
}
