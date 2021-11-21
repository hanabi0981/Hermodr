using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public Sprite[] ISprite = new Sprite[11];
    public int[] IPrice = new int[11];
    public int[] Ability = new int[11] { 0, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 }; 
    public void ItemAbility(int index)
    {
        switch (index)
        {
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
            case 7:
                Ability_07();
                break;
            case 8:
                Ability_08();
                break;
            case 9:
                Ability_09();
                break;
            case 10:
                Ability_10();
                break;
            default:
                break;
        }
    }
    private void Ability_01()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().damage += 10.0f;
        og.player.GetComponent<PlayerCombat>().timeBetAttack -= 0.2f;
    }
    private void Ability_02()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().damage += 5.0f;
    }
    private void Ability_03()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().attackRange += 0.2f;
    }
    private void Ability_04()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().moveSpeed = 3.0f;
    }
    private void Ability_05()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().startHealth += 10f;
    }
    private void Ability_06()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().damage += 20.0f;
        og.player.GetComponent<PlayerCombat>().timeBetAttack -= 0.4f;
    }
    private void Ability_07()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().startHealth -= 10.0f;
        og.player.GetComponent<PlayerCombat>().moveSpeed += 5;
    }
    private void Ability_08()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().startHealth += 20.0f;
        og.player.GetComponent<PlayerCombat>().moveSpeed -= 5.0f;
    }
    private void Ability_09()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().damage += 10.0f;
        og.player.GetComponent<PlayerCombat>().startHealth -= 10.0f;
    }
    private void Ability_10()
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        og.player.GetComponent<PlayerCombat>().timeBetAttack -= 0.1f;
    }
}