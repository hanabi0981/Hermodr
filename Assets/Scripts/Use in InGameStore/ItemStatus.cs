using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemStatus : MonoBehaviour
{
    public int itemindex;
    public GameObject selectedItem;
    public ItemsList itemsList;

    List<string> HaveItemNumber = InGameShopManager.HaveItemSpriteNumber2;
    List<string> HaveItemForgeNumber = InGameShopManager.HaveItemForgeNumber;
    private void OnEnable()
    {
        Image statusImage = GameObject.Find("Status image " + itemindex).GetComponent<Image>();
        Text statusName = GameObject.Find("Status name " + itemindex).GetComponent<Text>();
        Text statusForge = GameObject.Find("Status forge " + itemindex).GetComponent<Text>();
        Text statusAbility_01 = GameObject.Find("Status text " + itemindex).GetComponent<Text>();
        
        itemsList.ItemAbility(PlayerPrefs.GetInt(HaveItemNumber[itemindex]), PlayerPrefs.GetInt(HaveItemForgeNumber[itemindex]));
        float[] status = new float[5] { itemsList.maxHealth, itemsList.moveSpeed, itemsList.damage, itemsList.attackRange, itemsList.timeBetAttack };
        string statusText = "";
        statusImage.sprite = itemsList.ISprite[PlayerPrefs.GetInt(HaveItemNumber[itemindex])];
        statusName.text = itemsList.IName[PlayerPrefs.GetInt(HaveItemNumber[itemindex])];
        statusForge.text = "+" + PlayerPrefs.GetInt(HaveItemForgeNumber[itemindex]);
        for(int i = 0; i < status.Length; i++)
        {
            switch(i)
            {
                case 0:
                    if(status[i] != 0)
                    {
                        statusText += "\n최대 체력 : " + status[i] + "\n";
                    }
                    break;
                case 1:
                    if (status[i] != 0)
                    {
                        statusText += "\n이동 속도 : " + status[i] + "\n";
                    }
                    break;
                case 2:
                    if (status[i] != 0)
                    {
                        statusText += "\n데미지 : " + status[i] + "\n";
                    }
                    break;
                case 3:
                    if (status[i] != 0)
                    {
                        statusText += "\n공격 범위 : " + status[i] + "\n";
                    }
                    break;
                case 4:
                    if (status[i] != 0)
                    {
                        statusText += "\n공격 속도 : " + status[i] + "\n";
                    }
                    break;
            }
        }
        statusAbility_01.text = statusText;
    }
}
