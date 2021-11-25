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

    public GameObject playerMelee;
    public GameObject playerTank;
    public GameObject playerArcher;

    public Sprite[] heroLists = new Sprite[8];
    void Start()
    {
        // 플레이어가 인게임에서 가진 아이템 인덱스 초기화
        InGameShopManager.c = 1;
        // 플레이어가 클리어한 맵 갯수 초기화
        StageSelector.stageClear = 0;
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
        // 근접 공격 유닛 프리팹 초기화
        playerMelee.GetComponent<NewPlayerCombat>().startHealth = 100.0f;
        playerMelee.GetComponent<NewPlayerCombat>().moveSpeed = 1.0f;
        playerMelee.GetComponent<NewPlayerCombat>().damage = 25.0f;
        playerMelee.GetComponent<NewPlayerCombat>().attackRange = 1.0f;
        playerMelee.GetComponent<NewPlayerCombat>().timeBetAttack = 1.0f;
        // 탱커 유닛 프리팹 초기화
        playerTank.GetComponent<NewPlayerCombat>().startHealth = 200.0f;
        playerTank.GetComponent<NewPlayerCombat>().moveSpeed = 0.7f;
        playerTank.GetComponent<NewPlayerCombat>().damage = 10.0f;
        playerTank.GetComponent<NewPlayerCombat>().attackRange = 1.0f;
        playerTank.GetComponent<NewPlayerCombat>().timeBetAttack = 2.0f;
        // 궁수 공격 유닛 프리팹 초기화
        playerArcher.GetComponent<NewPlayerCombat>().startHealth = 50.0f;
        playerArcher.GetComponent<NewPlayerCombat>().moveSpeed = 1.1f;
        playerArcher.GetComponent<NewPlayerCombat>().damage = 10.0f;
        playerArcher.GetComponent<NewPlayerCombat>().attackRange = 4.0f;
        playerArcher.GetComponent<NewPlayerCombat>().timeBetAttack = 0.5f;
    }
}