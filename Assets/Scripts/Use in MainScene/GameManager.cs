using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject mainHero;

    void Start()
    {
        // 플레이어 프리팹 초기화
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage = 25.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
        // 메인 영웅 설정
        string heroSpritePath = PlayerPrefs.GetString("Main Hero");
        if(heroSpritePath != null)
        {
            int lastindex = heroSpritePath.LastIndexOf('.');
            string a1 = heroSpritePath.Substring(0, lastindex);
            string ResourceSpritePath = a1.Substring(17);
            mainHero.GetComponent<Image>().sprite = Resources.Load<Sprite>(ResourceSpritePath);
        }
    }
    public void Divine()
    {
        SceneManager.LoadScene("LobbyStore");
    }
}
