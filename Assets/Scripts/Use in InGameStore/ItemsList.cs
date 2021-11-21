#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemsList : MonoBehaviour
{
    public Sprite[] ISprite = new Sprite[11];
    public int[] IPrice = new int[11];

    public void ItemAbility(int index, int forge)
    {
        switch(index)
        {
            case 0:
                break;
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
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage += 10.0f;
        _object.GetComponent<PlayerCombat>().timeBetAttack -= (0.2f * (forge + 1));
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_02(int forge)
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage += (5.0f * (forge + 1));
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_03(int forge)
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().attackRange += (0.2f * (forge + 1));
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_04(int forge)
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().moveSpeed += ((forge + 1) * 2.0f + 1.0f);
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_05(int forge)
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().startHealth += (10f * (forge + 1));
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_06(int forge)
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage += 20f;
        _object.GetComponent<PlayerCombat>().timeBetAttack -= 0.4f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_07(int forge)
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().startHealth -= 10f;
        _object.GetComponent<PlayerCombat>().moveSpeed += 5.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_08(int forge)
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().startHealth += 20f;
        _object.GetComponent<PlayerCombat>().moveSpeed -= 5.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_09(int forge)
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage += 10f;
        _object.GetComponent<PlayerCombat>().startHealth -= 10.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_10(int forge)
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().timeBetAttack -= 0.1f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
}
#endif
