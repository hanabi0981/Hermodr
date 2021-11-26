using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DivineStatus : MonoBehaviour
{
    public int itemindex;
    public Sprite[] divineSprite = new Sprite[7];
    private string[] divineName = {"헤르모드","발키리", "굴베이그", "헤임달", "토르", "발두르", "오딘" };
    public int[] divinePrice = { 0, 1000, 1500, 2500, 3000, 3500, 6000 };
    private string[] divineAbility = {"\n       능력 없음",   " 아이템 강화 횟수 : \n +1", 
                                                " 기본 공격력 : +15", 
                                                " 시작 골드 : +150G", 
                                                " 엔트로피 보상 : \n +30%",
                                                " 아이템 갯수 +1 >> \n 최대체력 : +10",
                                                " 생명력 흡수 10%" };
    private void OnEnable()
    {
        Image statusImage = GameObject.Find("Status image " + itemindex).GetComponent<Image>();
        Text statusName = GameObject.Find("Status name " + itemindex).GetComponent<Text>();
        Text statusAbility_01 = GameObject.Find("Status text " + itemindex).GetComponent<Text>();

        if (itemindex == 0)
        {
            for (int i = 0; i < divineSprite.Length; i++)
            {
                if (GameObject.Find("GodsIcon").GetComponent<Image>().sprite == divineSprite[i])
                {
                    statusImage.sprite = divineSprite[i];
                    statusName.text = divineName[i];
                    statusAbility_01.text = divineAbility[i];
                }
            }
        }
        else
        {
            statusImage.sprite = divineSprite[itemindex];
            statusName.text = divineName[itemindex];
            statusAbility_01.text = divineAbility[itemindex];
        }
    }
}
