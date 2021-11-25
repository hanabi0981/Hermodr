using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemsList : MonoBehaviour
{
    public float maxHealth, moveSpeed, damage, attackRange, timeBetAttack;
    public Sprite[] ISprite = new Sprite[11];
    public int[] IPrice = new int[11];
    public string[] IName = new string[11] {"None", "Item 01", "Item 02", "Item 03", "Item 04", "Item 05",
                                            "Item 06", "Item 07", "Item 08", "Item 09", "Item 10", };
    public void ItemAbility(int index, int forge, string name)
    {
        maxHealth = moveSpeed = damage = attackRange = timeBetAttack = 0;
        switch (index)
        {
            case 1:
                Ability_01(forge, name);
                break;
            case 2:
                Ability_02(forge, name);
                break;
            case 3:
                Ability_03(forge, name);
                break;
            case 4:
                Ability_04(forge, name);
                break;
            case 5:
                Ability_05(forge, name);
                break;
            case 6:
                Ability_06(forge, name);
                break;
            case 7:
                Ability_07(forge, name);
                break;
            case 8:
                Ability_08(forge, name);
                break;
            case 9:
                Ability_09(forge, name);
                break;
            case 10:
                Ability_10(forge, name);
                break;
            default:
                break;
        }
    }
    private void Ability_01(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                damage = 10.0f;
                timeBetAttack = -0.2f;
                AddValue(name);
                break;
            case 1:
                damage = 10.0f;
                timeBetAttack = -0.4f;
                AddValue(name);
                break;
            case 2:
                damage = 10.0f;
                timeBetAttack = -0.6f;
                AddValue(name);
                break;
        }
    }
    private void Ability_02(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                damage = 5.0f;
                AddValue(name);
                break;
            case 1:
                damage = 10.0f;
                AddValue(name);
                break;
            case 2:
                damage = 15.0f;
                AddValue(name);
                break;
        }
    }
    private void Ability_03(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                attackRange = 0.2f;
                AddValue(name);
                break;
            case 1:
                attackRange = 0.4f;
                AddValue(name);
                break;
            case 2:
                attackRange = 0.6f;
                AddValue(name);
                break;
        }
    }
    private void Ability_04(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                moveSpeed = 0.3f;
                AddValue(name);
                break;
            case 1:
                moveSpeed = 0.5f;
                AddValue(name);
                break;
            case 2:
                moveSpeed = 0.7f;
                AddValue(name);
                break;
        }
    }
    private void Ability_05(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                maxHealth = 10.0f;
                AddValue(name);
                break;
            case 1:
                maxHealth = 20.0f;
                AddValue(name);
                break;
            case 2:
                maxHealth = 40.0f;
                AddValue(name);
                break;
        }
    }
    private void Ability_06(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                damage = 20.0f;
                timeBetAttack = -0.4f;
                AddValue(name);
                break;
            case 1:
                damage = 20.0f;
                timeBetAttack = -0.6f;
                AddValue(name);
                break;
            case 2:
                damage = 20.0f;
                timeBetAttack = -0.8f;
                AddValue(name);
                break;
        }
    }
    private void Ability_07(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                maxHealth = -10.0f;
                moveSpeed = 0.5f;
                AddValue(name);
                break;
            case 1:
                maxHealth = -15.0f;
                moveSpeed = 0.7f;
                AddValue(name);
                break;
            case 2:
                maxHealth = -15.0f;
                moveSpeed = 0.9f;
                AddValue(name);
                break;
        }
    }
    private void Ability_08(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                maxHealth = 20.0f;
                moveSpeed = -0.5f;
                AddValue(name);
                break;
            case 1:
                maxHealth = 20.0f;
                moveSpeed = -0.3f;
                AddValue(name);
                break;
            case 2:
                maxHealth = 20.0f;
                moveSpeed = -0.1f;
                AddValue(name);
                break;
        }
    }
    private void Ability_09(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                damage = 10.0f;
                maxHealth = -10.0f;
                AddValue(name);
                break;
            case 1:
                damage = 20.0f;
                maxHealth = -20.0f;
                AddValue(name);
                break;
            case 2:
                damage = 30.0f;
                maxHealth = -30.0f;
                AddValue(name);
                break;
        }
    }
    private void Ability_10(int forge, string name)
    {
        switch (forge)
        {
            case 0:
                timeBetAttack = -0.1f;
                AddValue(name);
                break;
            case 1:
                timeBetAttack = -0.2f;
                AddValue(name);
                break;
            case 2:
                timeBetAttack = -0.4f;
                AddValue(name);
                break;
        }
    }
    private void AddValue(string name)
    {
        if (name == "BattleManager")
        {
            ObjectGenerator og = GameObject.FindObjectOfType<ObjectGenerator>();
            // 근접 공격 유닛 능력치 적용.
            og.playerMelee.GetComponent<NewPlayerCombat>().startHealth += maxHealth;
            og.playerMelee.GetComponent<NewPlayerCombat>().moveSpeed += moveSpeed;
            og.playerMelee.GetComponent<NewPlayerCombat>().damage += damage;
            og.playerMelee.GetComponent<NewPlayerCombat>().attackRange += attackRange;
            og.playerMelee.GetComponent<NewPlayerCombat>().timeBetAttack += timeBetAttack;
            // 탱커 유닛 능력치 적용.
            og.playerTank.GetComponent<NewPlayerCombat>().startHealth += maxHealth;
            og.playerTank.GetComponent<NewPlayerCombat>().moveSpeed += moveSpeed;
            og.playerTank.GetComponent<NewPlayerCombat>().damage += damage;
            og.playerTank.GetComponent<NewPlayerCombat>().attackRange += attackRange;
            og.playerTank.GetComponent<NewPlayerCombat>().timeBetAttack += timeBetAttack;
            // 궁수 유닛 능력치 적용.
            og.playerTank.GetComponent<NewPlayerCombat>().startHealth += maxHealth;
            og.playerTank.GetComponent<NewPlayerCombat>().moveSpeed += moveSpeed;
            og.playerTank.GetComponent<NewPlayerCombat>().damage += damage;
            og.playerTank.GetComponent<NewPlayerCombat>().attackRange += attackRange;
            og.playerTank.GetComponent<NewPlayerCombat>().timeBetAttack += timeBetAttack;
        }
    }
}