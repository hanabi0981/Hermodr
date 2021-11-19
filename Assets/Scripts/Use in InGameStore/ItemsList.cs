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
            case 7:
                Ability_01();
                break;
            case 8:
                Ability_01();
                break;
            case 9:
                Ability_01();
                break;
            case 10:
                Ability_01();
                break;
            default:
                break;
        }
    }
    private void Ability_01()
    {
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage = 100.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }
}
