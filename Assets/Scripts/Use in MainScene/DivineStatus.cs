using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DivineStatus : MonoBehaviour
{
    public int itemindex;
    public Sprite[] divineSprite = new Sprite[7];
    private string[] divineName = {"Divine 0","Divine 01", "Divine 02", "Divine 03", "Divine 04", "Divine 05", "Divine 06" };
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
    public void DivineAblilty(int i)
    {
        Reset();
        switch(i)
        {
            case 0:
                Ability_00();
                break;
            case 1:
                Ability_01();
                break;
            case 2:
                Ability_01();
                break;
            case 3:
                Ability_01();
                break;
            case 4:
                Ability_01();
                break;
            case 5:
                Ability_01();
                break;
            case 6:
                Ability_01();
                break;
        }
    }
    private void Reset()
    {
        //1 번 능력 초기화
        PlayerPrefs.SetInt("charForgeChance", 1);
        //2 번 능력 초기화
        //3 번 능력 초기화
        //4 번 능력 초기화
        //5 번 능력 초기화
        //6 번 능력 초기화
    }
    private void Ability_00()
    {
        ;
    }
    private void Ability_01()
    {
        PlayerPrefs.SetInt("charForgeChance", 2);
    }
}
