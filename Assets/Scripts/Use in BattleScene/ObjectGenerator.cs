using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject[] playerItems = new GameObject[6];

    public static int killcount = 0;

    private void Start()
    {
        //for (int i = 1; i < playerItems.Length; i++)
        //{
        //    // InGameShopManager가 정상적으로 DontDestroyOnLoad에 존재한다면, 
        //    if (InGameShopManager.instance != null)
        //    {
        //        // playerItems의 sprite를, 구매된 sprite의 index 값을 가져와 설정.
        //        playerItems[i].GetComponent<Image>().sprite = InGameShopManager.instance.iL.ISprite[InGameShopManager.instance.HaveItemSpriteNumber[i]];
        //        // 초기상태는 전부 비활성이므로, sprite가 변경된 gameobject만 활성화.
        //        if (playerItems[i].GetComponent<Image>().sprite != null)
        //        {
        //            playerItems[i].SetActive(true);
        //        }
        //    }
        //}
        
        List<string> HaveItemNumber = InGameShopManager.HaveItemSpriteNumber2;
        for (int i = 1; i < HaveItemNumber.Count; i++)
        {
            // Debug.Log("선택된 아이템 넘버 : " + PlayerPrefs.GetInt(HaveItemNumber[i]));
            playerItems[i].GetComponent<Image>().sprite = GetComponent<ItemsList>().ISprite[PlayerPrefs.GetInt(HaveItemNumber[i])];
            GetComponent<ItemsList>().ItemAbility(PlayerPrefs.GetInt(HaveItemNumber[i]));
            GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
            float damage = _object.GetComponent<PlayerCombat>().damage;
            float attackRange = _object.GetComponent<PlayerCombat>().attackRange;
            float timeBetAttack = _object.GetComponent<PlayerCombat>().timeBetAttack;
            float moveSpeed = _object.GetComponent<PlayerCombat>().moveSpeed;
            float startHealth = _object.GetComponent<PlayerCombat>().startHealth;
            PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
            PrefabUtility.UnloadPrefabContents(_object);
            Debug.Log("플레이어 공격력 : " + damage + "\n" +
                        "플레이어 공격거리 : " + attackRange + "\n" +
                        "플레이어 공격속도 : " + timeBetAttack + "\n" +
                        "플레이어 이동속도 : " + moveSpeed + "\n" +
                        "플레이어 최대체력 : " + startHealth + "\n");
        }
        SpawnEnemy();
        Invoke("SpawnEnemy", 2);

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Instantiate(player);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Instantiate(enemy);
        }
        if (killcount >= 2 && SceneManager.GetActiveScene().name!="Battle")
        {            
            Invoke("InGameShopLoad", 2);
            killcount = 0;
        }
        else if (killcount >= 2 && SceneManager.GetActiveScene().name == "Battle")
        {
            Invoke("MainLoad", 2);
            killcount = 0;
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemy);
    }

    void InGameShopLoad()
    {
        SceneManager.LoadScene("InGameStore");
    }

    void MainLoad()
    {
        SceneManager.LoadScene("Main");
    }
}