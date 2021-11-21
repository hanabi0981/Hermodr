using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour
{
    public Sprite[] ISprite = new Sprite[11];
    public int[] IPrice = new int[11];
    public int[] Ability = new int[11] { 0, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 }; 
    public void ItemAbility(int index, int forge)
    {

        switch (index)
        {
            case 1:
                Ability_01(forge);
                break;
            case 2:
                Ability_02(forge);
                break;
            case 3:
                Ability_03(forge);
                break;
            case 4:
                Ability_04(forge);
                break;
            case 5:
                Ability_05(forge);
                break;
            case 6:
                Ability_06(forge);
                break;
            case 7:
                Ability_07(forge);
                break;
            case 8:
                Ability_08(forge);
                break;
            case 9:
                Ability_09(forge);
                break;
            case 10:
                Ability_10(forge);
                break;
            default:
                break;
        }
    }
    private void Ability_01(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().damage += 10.0f;
                og.player.GetComponent<PlayerCombat>().timeBetAttack -= 0.2f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().damage += 10.0f;
                og.player.GetComponent<PlayerCombat>().timeBetAttack -= 0.4f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().damage += 10.0f;
                og.player.GetComponent<PlayerCombat>().timeBetAttack -= 0.6f;
                break;
        }
    }
    private void Ability_02(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().damage += 5.0f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().damage += 10.0f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().damage += 15.0f;
                break;
        }
    }
    private void Ability_03(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().attackRange += 0.2f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().attackRange += 0.4f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().attackRange += 0.6f;
                break;
        }
    }
    private void Ability_04(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().moveSpeed += 0.3f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().moveSpeed += 0.5f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().moveSpeed += 0.7f;
                break;
        }
    }
    private void Ability_05(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().startHealth += 10f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().startHealth += 20f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().startHealth += 40f;
                break;
        }
    }
    private void Ability_06(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().damage += 20.0f;
                og.player.GetComponent<PlayerCombat>().timeBetAttack = 0.6f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().damage += 20.0f;
                og.player.GetComponent<PlayerCombat>().timeBetAttack = 0.4f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().damage += 20.0f;
                og.player.GetComponent<PlayerCombat>().timeBetAttack = 0.2f;
                break;
        }
    }
    private void Ability_07(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().startHealth -= 10.0f;
                og.player.GetComponent<PlayerCombat>().moveSpeed += 0.5f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().startHealth -= 15.0f;
                og.player.GetComponent<PlayerCombat>().moveSpeed += 0.7f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().startHealth -= 15.0f;
                og.player.GetComponent<PlayerCombat>().moveSpeed += 0.9f;
                break;
        }
    }
    private void Ability_08(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().startHealth += 20.0f;
                og.player.GetComponent<PlayerCombat>().moveSpeed -= 0.5f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().startHealth += 20.0f;
                og.player.GetComponent<PlayerCombat>().moveSpeed -= 0.3f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().startHealth += 20.0f;
                og.player.GetComponent<PlayerCombat>().moveSpeed -= 0.1f;
                break;
        }
    }
    private void Ability_09(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().damage += 10.0f;
                og.player.GetComponent<PlayerCombat>().startHealth -= 10.0f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().damage += 20.0f;
                og.player.GetComponent<PlayerCombat>().startHealth -= 20.0f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().damage += 30.0f;
                og.player.GetComponent<PlayerCombat>().startHealth -= 30.0f;
                break;
        }
    }
    private void Ability_10(int forge)
    {
        ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
        switch (forge)
        {
            case 0:
                og.player.GetComponent<PlayerCombat>().timeBetAttack -= 0.1f;
                break;
            case 1:
                og.player.GetComponent<PlayerCombat>().timeBetAttack -= 0.2f;
                break;
            case 2:
                og.player.GetComponent<PlayerCombat>().timeBetAttack -= 0.4f;
                break;
        }
        
    }
}