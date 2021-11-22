using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject stageClear;
   
    public GameObject[] playerItems = new GameObject[6];

    public static int killcount = 0;

    List<string> HaveItemNumber = InGameShopManager.HaveItemSpriteNumber2;
    List<string> HaveItemForgeNumber = InGameShopManager.HaveItemForgeNumber;

    private void Start()
    {
        for (int i = 1; i < HaveItemNumber.Count; i++)
        {
            Debug.Log("선택된 아이템 넘버 : " + PlayerPrefs.GetInt(HaveItemNumber[i]));
            playerItems[i].GetComponent<Image>().sprite = GetComponent<ItemsList>().ISprite[PlayerPrefs.GetInt(HaveItemNumber[i])];
            playerItems[i].GetComponentInChildren<Text>().text = "+" + PlayerPrefs.GetInt(HaveItemForgeNumber[i]);
            playerItems[i].GetComponent<ItemsList>().ItemAbility(PlayerPrefs.GetInt(HaveItemNumber[i]), PlayerPrefs.GetInt(HaveItemForgeNumber[i]));

            int forge = int.Parse(playerItems[i].GetComponentInChildren<Text>().text.ToString().Substring(1));
            if(forge == 0)
            {
                playerItems[i].GetComponentInChildren<Text>().color = new Color(0, 0, 0, 0);
            }
        }
        // 스테이지 클리어/엔드 UI 초기화
        stageClear.SetActive(false);
        //
      
        float damage = player.GetComponent<PlayerCombat>().damage;
        float attackRange = player.GetComponent<PlayerCombat>().attackRange;
        float timeBetAttack = player.GetComponent<PlayerCombat>().timeBetAttack;
        float startHealth = player.GetComponent<PlayerCombat>().startHealth;
        float moveSpeed = player.GetComponent<PlayerCombat>().moveSpeed;
        Debug.Log("플레이어의 공격력 : " + damage + "\n" +
                    "플레이어의 공격범위 : " + attackRange + "\n" +
                    "플레이어의 공격속도 : " + timeBetAttack + "\n" + 
                    "플레이어의 최대체력 : " + startHealth + "\n" + 
                    "플레이어의 이동속도 : " + moveSpeed );
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
            stageClear.SetActive(true);
            Text clearText = GameObject.Find("clearText").GetComponent<Text>();
            Text gainGold = GameObject.Find("gainGold").GetComponent<Text>();
            Text gainEnt = GameObject.Find("gainEnt").GetComponent<Text>();

            int stageClearGold = StageSelector.stageClear * 150;
            float stageClearEnt = stageClearGold * 0.1f;

            gainEnt.text = "+" + stageClearEnt + " E";

            stageClearEnt = PlayerPrefs.GetFloat("Stage Ent") + stageClearEnt;
            PlayerPrefs.SetFloat("Stage Ent", stageClearEnt);

            clearText.text = "! 스테이지 클리어 !";
            gainGold.text = "+" + stageClearGold + " G";

            InGameShopManager.coins += stageClearGold;

            Invoke("InGameShopLoad", 3);
            killcount = 0;
        }
        else if (killcount >= 2 && SceneManager.GetActiveScene().name == "Battle")
        {
            stageClear.SetActive(true);
            Text clearText = GameObject.Find("clearText").GetComponent<Text>();
            Text gainGold = GameObject.Find("gainGold").GetComponent<Text>();
            Text gainEnt = GameObject.Find("gainEnt").GetComponent<Text>();

            float stageClearEnt = 500.0f;

            stageClearEnt = PlayerPrefs.GetFloat("Stage Ent") + stageClearEnt;
            PlayerPrefs.SetFloat("Stage Ent", stageClearEnt);
            float totalClearEnt = PlayerPrefs.GetFloat("Total Ent") + stageClearEnt;
            PlayerPrefs.SetFloat("Total Ent", totalClearEnt);
            gainGold.text = "+0 G";
            Debug.Log(totalClearEnt);
            gainEnt.text = "+" + stageClearEnt + " E  >>> Total : " + totalClearEnt + " E";

            Invoke("MainLoad", 3);
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