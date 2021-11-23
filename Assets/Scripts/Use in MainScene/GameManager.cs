using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }
    private static GameManager m_instance;
    public Image mainHeroImage;
    public Image windowHeroImage;
    public GameObject player;
    public Sprite[] heroLists = new Sprite[8];
    void Start()
    {
        // 플레이어가 인게임에서 가진 아이템 인덱스 초기화
        InGameShopManager.c = 1;
        // 플레이어가 클리어한 맵 갯수 초기화
        PlayerPrefs.DeleteKey("stageClear");
        // 골드 값 초기화
        InGameShopManager.coins = 0;
        // 스테이지 엔트로피 초기화
        PlayerPrefs.SetFloat("Stage Ent", 0.0f);
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
        // 메인 영웅 & 신성 팝업 영웅 설정
        if(PlayerPrefs.GetInt("Main Hero") != 0)
        {
            mainHeroImage.sprite = heroLists[PlayerPrefs.GetInt("Main Hero")];
            windowHeroImage.sprite = heroLists[PlayerPrefs.GetInt("Main Hero")];
        }
        // 플레이어 프리팹 초기화
        player.GetComponent<PlayerCombat>().startHealth = 100.0f;
        player.GetComponent<PlayerCombat>().moveSpeed = 1.0f;
        player.GetComponent<PlayerCombat>().damage = 25.0f;
        player.GetComponent<PlayerCombat>().attackRange = 0.6f;
        player.GetComponent<PlayerCombat>().timeBetAttack = 1.0f;
    }
}