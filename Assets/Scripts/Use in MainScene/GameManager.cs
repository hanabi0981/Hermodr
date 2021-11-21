using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject mainHero;
    public Sprite[] heroLists = new Sprite[8];
    void Start()
    {
        // 플레이어가 인게임에서 가진 아이템 인덱스 초기화
        InGameShopManager.c = 1;

        // 플레이어가 가진 아이템 수 초기화
        for (int i = 0; i < InGameShopManager.HaveItemSpriteNumber2.Count; i++)
        {
            PlayerPrefs.DeleteKey(InGameShopManager.HaveItemSpriteNumber2[i]);
            PlayerPrefs.SetInt(InGameShopManager.HaveItemSpriteNumber2[i], 0);
        }
        // 플레이어가 가진 아이템의 강화수치 초기화
        for (int i = 0; i < InGameShopManager.HaveItemForgeNumber.Count; i++)
        {
            PlayerPrefs.DeleteKey(InGameShopManager.HaveItemForgeNumber[i]);
        }
        // 메인 영웅 설정
        if(PlayerPrefs.GetInt("Main Hero") != 100)
        {
            mainHero.GetComponent<Image>().sprite = heroLists[PlayerPrefs.GetInt("Main Hero")];
        }
    }
    public void Divine()
    {
        SceneManager.LoadScene("LobbyStore");
    }
}