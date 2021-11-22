using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestBookManager : MonoBehaviour
{
    public Button questBook1, questBook2, questBook3, questBook4, questBook5, questBook6;
    public Text questTitle;
    public Text questDescription1, questDescription2, questDescription3;

    Dictionary<string, string> QuestDic = new Dictionary<string, string>()
    {
        {"questBook1", "첫 전투"},
        {"description1_Book1", "시나리오 진행"},
        {"description2_Book1", "적 처치"},
        {"description3_Book1", ""},
        {"questBook2", "questTitle : PIXEL"},
        {"description1_Book2", "TeamPIXEL"},
        {"description2_Book2", "Hermodr"},
        {"description3_Book2", "C++A+"},
        {"questBook3", "questTitle : 북유럽 신화"},
        {"description1_Book3", "로키"},
        {"description2_Book3", "로키오딘"},
        {"description3_Book3", "로키오딘토르"},
        {"questBook4", "questTitle : 헤르모드"},
        {"description1_Book4", "한글"},
        {"description2_Book4", "한글 테스트"},
        {"description3_Book4", "정렬 테스트의 정렬 테스트의 정렬 테스트의 정렬 테스트의 정렬 테스트의 정렬 테스트의 정렬 테스트의 테스트"},
        {"questBook5", "questTitle : 퀘스트"},
        {"description1_Book5", "TestTestTest"},
        {"description2_Book5", "TestTestTest"},
        {"description3_Book5", "TestTestTest"},
        {"questBook6", "questTitle : null data"},
        {"description1_Book6", "TestTestTest"},
        {"description2_Book6", "TestTestTest"},
        {"description3_Book6", "TestTestTest"},
    };


    public void QuestBook1Selected()
    {
        QuestDic.TryGetValue("questBook1", out string questBook1);
        QuestDic.TryGetValue("description1_Book1", out string description1_Book1);
        QuestDic.TryGetValue("description2_Book1", out string description2_Book1);
        QuestDic.TryGetValue("description3_Book1", out string description3_Book1);

        questTitle.text = questBook1;
        questDescription1.text = description1_Book1;
        questDescription2.text = description2_Book1;
        questDescription3.text = description3_Book1;

        PlayerPrefs.SetString("questTitle", questBook1);
        PlayerPrefs.SetString("questDescription1", description1_Book1);
        PlayerPrefs.SetString("questDescription2", description2_Book1);
        PlayerPrefs.SetString("questDescription3", description3_Book1);
    }
    public void QuestBook2Selected()
    {
        QuestDic.TryGetValue("questBook2", out string questBook2);
        QuestDic.TryGetValue("description1_Book2", out string description1_Book2);
        QuestDic.TryGetValue("description2_Book2", out string description2_Book2);
        QuestDic.TryGetValue("description3_Book2", out string description3_Book2);

        questTitle.text = questBook2;
        questDescription1.text = description1_Book2;
        questDescription2.text = description2_Book2;
        questDescription3.text = description3_Book2;
    }
    public void QuestBook3Selected()
    {
        QuestDic.TryGetValue("questBook3", out string questBook3);
        QuestDic.TryGetValue("description1_Book3", out string description1_Book3);
        QuestDic.TryGetValue("description2_Book3", out string description2_Book3);
        QuestDic.TryGetValue("description3_Book3", out string description3_Book3);

        questTitle.text = questBook3;
        questDescription1.text = description1_Book3;
        questDescription2.text = description2_Book3;
        questDescription3.text = description3_Book3;
    }
    public void QuestBook4Selected()
    {
        QuestDic.TryGetValue("questBook4", out string questBook4);
        QuestDic.TryGetValue("description1_Book4", out string description1_Book4);
        QuestDic.TryGetValue("description2_Book4", out string description2_Book4);
        QuestDic.TryGetValue("description3_Book4", out string description3_Book4);

        questTitle.text = questBook4;
        questDescription1.text = description1_Book4;
        questDescription2.text = description2_Book4;
        questDescription3.text = description3_Book4;
    }
    public void QuestBook5Selected()
    {
        QuestDic.TryGetValue("questBook5", out string questBook5);
        QuestDic.TryGetValue("description1_Book5", out string description1_Book5);
        QuestDic.TryGetValue("description2_Book5", out string description2_Book5);
        QuestDic.TryGetValue("description3_Book5", out string description3_Book5);

        questTitle.text = questBook5;
        questDescription1.text = description1_Book5;
        questDescription2.text = description2_Book5;
        questDescription3.text = description3_Book5;
    }
    public void QuestBook6Selected()
    {
        QuestDic.TryGetValue("questBook6", out string questBook6);
        QuestDic.TryGetValue("description1_Book6", out string description1_Book6);
        QuestDic.TryGetValue("description2_Book6", out string description2_Book6);
        QuestDic.TryGetValue("description3_Book6", out string description3_Book6);

        questTitle.text = questBook6;
        questDescription1.text = description1_Book6;
        questDescription2.text = description2_Book6;
        questDescription3.text = description3_Book6;
    }
}
