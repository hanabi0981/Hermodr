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
        {"questBook1", "도르마 벗어나기"},
        {"description1_Book1", "숲 스테이지 클리어"},
        {"description2_Book1", "숲의 괴물 5마리 처치"},
        {"description3_Book1", "숲의 괴물 10마리 처치"},
        {"questBook2", "황소 머리로 낚시하기"},
        {"description1_Book2", "토르 획득"},
        {"description2_Book2", "늪 스테이지 클리어"},
        {"description3_Book2", "늪의 괴물 10마리 처치"},
        {"questBook3", "발두르의 친구"},
        {"description1_Book3", "발두르 획득"},
        {"description2_Book3", "지옥 스테이지 클리어"},
        {"description3_Book3", "지옥의 괴물 10마리 처치"},
        {"questBook4", "라그나로크의 주인"},
        {"description1_Book4", "모든 스테이지 클리어"},
        {"description2_Book4", "황혼의 괴물 10마리 처치"},
        {"description3_Book4", "모든 괴물 100마리 처치"},
        {"questBook5", "황금의 시대"},
        {"description1_Book5", "모든 스테이지 4회 클리어"},
        {"description2_Book5", "모든 신성 획득"},
        {"description3_Book5", "토벌 로키 클리어"},
        {"questBook6", "정해진 운명"},
        {"description1_Book6", "숲 스테이지 클리어 실패"},
        {"description2_Book6", "늪 스테이지 클리어 실패"},
        {"description3_Book6", "지옥 스테이지 클리어 실패"},
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

        PlayerPrefs.SetInt("selectedQuest", 1);
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

        PlayerPrefs.SetString("questTitle", questBook2);
        PlayerPrefs.SetString("questDescription1", description1_Book2);
        PlayerPrefs.SetString("questDescription2", description2_Book2);
        PlayerPrefs.SetString("questDescription3", description3_Book2);

        PlayerPrefs.SetInt("selectedQuest", 2);
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

        PlayerPrefs.SetString("questTitle", questBook3);
        PlayerPrefs.SetString("questDescription1", description1_Book3);
        PlayerPrefs.SetString("questDescription2", description2_Book3);
        PlayerPrefs.SetString("questDescription3", description3_Book3);

        PlayerPrefs.SetInt("selectedQuest", 3);
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

        PlayerPrefs.SetString("questTitle", questBook4);
        PlayerPrefs.SetString("questDescription1", description1_Book4);
        PlayerPrefs.SetString("questDescription2", description2_Book4);
        PlayerPrefs.SetString("questDescription3", description3_Book4);

        PlayerPrefs.SetInt("selectedQuest", 4);
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

        PlayerPrefs.SetString("questTitle", questBook5);
        PlayerPrefs.SetString("questDescription1", description1_Book5);
        PlayerPrefs.SetString("questDescription2", description2_Book5);
        PlayerPrefs.SetString("questDescription3", description3_Book5);

        PlayerPrefs.SetInt("selectedQuest", 5);
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

        PlayerPrefs.SetString("questTitle", questBook6);
        PlayerPrefs.SetString("questDescription1", description1_Book6);
        PlayerPrefs.SetString("questDescription2", description2_Book6);
        PlayerPrefs.SetString("questDescription3", description3_Book6);

        PlayerPrefs.SetInt("selectedQuest", 6);
    }
}
