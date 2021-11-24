using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivineAbility : MonoBehaviour
{
    public Sprite[] divineSprite = new Sprite[7];
    public void DivineAblilty(int i)
    {
        Reset();
        switch (i)
        {
            case 0:
                Ability_00();
                break;
            case 1:
                Ability_01();
                break;
            case 2:
                Ability_02();
                break;
            case 3:
                Ability_03();
                break;
            case 4:
                Ability_04();
                break;
            case 5:
                Ability_05();
                break;
            case 6:
                Ability_06();
                break;
        }
    }
    private void Reset()
    {
        //1 번 능력 초기화
        PlayerPrefs.SetInt("charForgeChance", 1);
        //2 번 능력 초기화
        PlayerPrefs.SetFloat("charDamage", 25.0f);
        GameManager.instance.player.GetComponent<PlayerCombat>().damage = PlayerPrefs.GetFloat("charDamage");
        //3 번 능력 초기화
        InGameShopManager.coins = 0;
        //4 번 능력 초기화
        PlayerPrefs.SetFloat("charGainEnt", 1.0f);
        //5 번 능력 초기화
        PlayerPrefs.SetInt("charGetHealthPerItem", 0);
        //6 번 능력 초기화
        PlayerPrefs.SetFloat("charLifeSteal", 0.0f);
    }
    private void Ability_00()
    {
        ;
    }
    private void Ability_01()
    {
        PlayerPrefs.SetInt("charForgeChance", 2);
    }
    private void Ability_02()
    {
        float addDamage = GameManager.instance.player.GetComponent<PlayerCombat>().damage + 15;
        GameManager.instance.player.GetComponent<PlayerCombat>().damage = addDamage;
        PlayerPrefs.SetFloat("charDamage", addDamage);
    }
    private void Ability_03()
    {
        InGameShopManager.coins += 150;
    }
    private void Ability_04()
    {
        PlayerPrefs.SetFloat("charGainEnt", 1.3f);
    }
    private void Ability_05()
    {
        PlayerPrefs.SetInt("charGetHealthPerItem", 10);
    }
    private void Ability_06()
    {
        PlayerPrefs.SetFloat("charLifeSteal", 0.1f);
    }
}
