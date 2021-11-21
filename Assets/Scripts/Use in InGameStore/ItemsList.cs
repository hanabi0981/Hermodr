using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ItemsList : MonoBehaviour
{
    public Sprite[] ISprite = new Sprite[11];
    public int[] IPrice = new int[11];

    public void ItemAbility(int index)
    {
        switch(index)
        {
            case 0:
                break;
            case 1:
                Ability_05();
                break;
            case 2:
                Ability_05();
                break;
            case 3:
                Ability_05();
                break;
            case 4:
                Ability_05();
                break;
            case 5:
                Ability_05();
                break;
            case 6:
                Ability_05();
                break;
            case 7:
                Ability_05();
                break;
            case 8:
                Ability_05();
                break;
            case 9:
                Ability_05();
                break;
            case 10:
                Ability_05();
                break;
            default:
                break;
        }
    }
    private void Ability_01()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage += 10.0f;
        _object.GetComponent<PlayerCombat>().timeBetAttack -= 0.2f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_02()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage += 5.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_03()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().attackRange += 0.2f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_04()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().moveSpeed += 3.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_05()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().startHealth += 10f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_06()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage += 20f;
        _object.GetComponent<PlayerCombat>().timeBetAttack += 0.6f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_07()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().startHealth -= 10f;
        _object.GetComponent<PlayerCombat>().moveSpeed += 5.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_08()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().startHealth += 20f;
        _object.GetComponent<PlayerCombat>().moveSpeed -= 5.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_09()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage += 10f;
        _object.GetComponent<PlayerCombat>().startHealth -= 10.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
    private void Ability_10()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().timeBetAttack -= 0.1f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
}
