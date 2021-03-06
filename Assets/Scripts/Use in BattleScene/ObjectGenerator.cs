using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject playerMelee;
    public GameObject playerTank;
    public GameObject playerArcher;

    public GameObject enemy;
    public GameObject stageClear;
   
    public GameObject[] playerItems = new GameObject[6];
    public static int killcount = 0;

    List<string> HaveItemNumber = InGameShopManager.HaveItemSpriteNumber2;
    List<string> HaveItemForgeNumber = InGameShopManager.HaveItemForgeNumber;

    public int totalEnemy;
    public int remainEnemy;

    public int haveItemCount;
    private BossCombat bc;

    int bossKillcount;
    private void Start()
    {
        // 보유 아이템 이미지 / 실제 능력치 적용
        for (int i = 1; i < HaveItemNumber.Count; i++)
        {
            Debug.Log("선택된 아이템 넘버 : " + PlayerPrefs.GetInt(HaveItemNumber[i]));
            playerItems[i].GetComponent<Image>().sprite = GetComponent<ItemsList>().ISprite[PlayerPrefs.GetInt(HaveItemNumber[i])];
            playerItems[i].GetComponentInChildren<Text>().text = "+" + PlayerPrefs.GetInt(HaveItemForgeNumber[i]);
            playerItems[i].GetComponent<ItemsList>().ItemAbility(PlayerPrefs.GetInt(HaveItemNumber[i]), PlayerPrefs.GetInt(HaveItemForgeNumber[i]), this.name);
            if(PlayerPrefs.GetInt(HaveItemNumber[i]) != 0)
            {
                haveItemCount++;
            }
            int forge = int.Parse(playerItems[i].GetComponentInChildren<Text>().text.ToString().Substring(1));
            if(forge == 0)
            {
                playerItems[i].GetComponentInChildren<Text>().color = new Color(0, 0, 0, 0);
            }
        }
        // 스테이지 클리어/엔드 UI 초기화
        stageClear.SetActive(false);
        // 신성 5 : 아이템 갯수 따라 체력 증가 적용/미적용
        playerMelee.GetComponent<NewPlayerCombat>().startHealth += haveItemCount * PlayerPrefs.GetInt("charGetHealthPerItem");
        playerTank.GetComponent<NewPlayerCombat>().startHealth += haveItemCount * PlayerPrefs.GetInt("charGetHealthPerItem");
        playerArcher.GetComponent<NewPlayerCombat>().startHealth += haveItemCount * PlayerPrefs.GetInt("charGetHealthPerItem");

        //float damage = player.GetComponent<NewPlayerCombat>().damage;
        //float attackRange = player.GetComponent<NewPlayerCombat>().attackRange;
        //float timeBetAttack = player.GetComponent<NewPlayerCombat>().timeBetAttack;
        //float startHealth = player.GetComponent<NewPlayerCombat>().startHealth;
        //float moveSpeed = player.GetComponent<NewPlayerCombat>().moveSpeed;
        //Debug.Log("플레이어의 공격력 : " + damage + "\n" +
        //            "플레이어의 공격범위 : " + attackRange + "\n" +
        //            "플레이어의 공격속도 : " + timeBetAttack + "\n" + 
        //            "플레이어의 최대체력 : " + startHealth + "\n" + 
        //            "플레이어의 이동속도 : " + moveSpeed );
        // 적 스테이지클리어 횟수를 참조하여 소환.
        if (enemy.name == "Hell Giant")
        {
            if (StageSelector.stageClear == 1)
            {
                totalEnemy = StageSelector.stageClear + 6;
                remainEnemy = totalEnemy;
                SpawnEnemy();
                StartCoroutine(SpawnGiantRepeat());
            }
            else if (StageSelector.stageClear == 2)
            {
                totalEnemy = StageSelector.stageClear + 6;
                remainEnemy = totalEnemy;
                SpawnEnemy();
                StartCoroutine(SpawnGiantRepeat());
            }
            else if (StageSelector.stageClear == 3)
            {
                totalEnemy = StageSelector.stageClear + 6;
                remainEnemy = totalEnemy;
                SpawnEnemy();
                StartCoroutine(SpawnGiantRepeat());
            }
        }
        else if(enemy.name == "Forest Wolf")
        {
            if(StageSelector.stageClear == 1)
            {
                totalEnemy = StageSelector.stageClear + 14;
                remainEnemy = totalEnemy;
                SpawnEnemy();
                StartCoroutine(SpawnWolfRepeat());
            }
            else if (StageSelector.stageClear == 2)
            {
                totalEnemy = StageSelector.stageClear + 15;
                remainEnemy = totalEnemy;
                SpawnEnemy();
                StartCoroutine(SpawnWolfRepeat());
            }
            else if (StageSelector.stageClear == 3)
            {
                totalEnemy = StageSelector.stageClear + 15;
                remainEnemy = totalEnemy;
                SpawnEnemy();
                StartCoroutine(SpawnWolfRepeat());
            }
        }
        else if(enemy.name == "Sea_Shell")
        {
            if(StageSelector.stageClear == 1)
            {
                totalEnemy = StageSelector.stageClear + 9;
                remainEnemy = totalEnemy;
                SpawnEnemy();
                StartCoroutine(SpawnShellRepeat());
            }
            else if (StageSelector.stageClear == 2)
            {
                totalEnemy = StageSelector.stageClear + 10;
                remainEnemy = totalEnemy;
                SpawnEnemy();
                StartCoroutine(SpawnShellRepeat());
            }
            else if (StageSelector.stageClear == 3)
            {
                totalEnemy = StageSelector.stageClear + 11;
                remainEnemy = totalEnemy;
                SpawnEnemy();
                StartCoroutine(SpawnShellRepeat());
            }
        }
        else if(enemy.name == "Boss_Loki")
        {
            // 보스전 레벨 디자인
            totalEnemy = 1;
            remainEnemy = totalEnemy;
            if (SceneManager.GetActiveScene().name != "Suppress")
            {
                SpawnEnemy();
            }
            bc = GameObject.FindObjectOfType<BossCombat>().GetComponent<BossCombat>();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (bc != null)
        {
            bossKillcount = bc.BossKill;
        }
        else
        {
            bossKillcount = 0;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
           
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Instantiate(enemy);
        }
        if (killcount >= totalEnemy && enemy.name != "Boss_Loki")
        {
            //스테이지 클리어 검사
            if (SceneManager.GetActiveScene().name == "Battle1")
            {
                PlayerPrefs.SetInt("trp_04", 1);
            }
            else if(SceneManager.GetActiveScene().name == "Battle2")
            {
                PlayerPrefs.SetInt("trp_02", 1);
            }
            else if(SceneManager.GetActiveScene().name == "Battle3")
            {
                PlayerPrefs.SetInt("trp_03", 1);
            }

            stageClear.SetActive(true);

            LifeEntity[] G_lf = GameObject.FindObjectsOfType<LifeEntity>();
            Text clearText = GameObject.Find("clearText").GetComponent<Text>();
            Text gainGold = GameObject.Find("gainGold").GetComponent<Text>();
            Text gainEnt = GameObject.Find("gainEnt").GetComponent<Text>();

            // 전투 종료 시 전부 idle 로 바꿈.
            for(int i = 0; i < G_lf.Length; i++)
            {
                G_lf[i].isDead = true;
            }

            int stageClearGold = StageSelector.stageClear * 150;
            float stageClearEnt = stageClearGold * 0.1f * PlayerPrefs.GetFloat("charGainEnt");

            gainEnt.text = "+" + (int) stageClearEnt + " E";

            stageClearEnt = PlayerPrefs.GetInt("Stage Ent") + stageClearEnt;
            PlayerPrefs.SetInt("Stage Ent", (int) stageClearEnt);

            clearText.text = "! 스테이지 클리어 !";
            gainGold.text = "+" + stageClearGold + " G";

            InGameShopManager.coins += stageClearGold;

            //Invoke("InGameShopLoad", 3);
            killcount = 0;
        }
        else if (bossKillcount > 0 && enemy.name == "Boss_Loki")
        {
            //보스 클리어 검사
            if(SceneManager.GetActiveScene().name == "Battle")
            {
                PlayerPrefs.SetInt("trp_05", 1);
            }
            else if(SceneManager.GetActiveScene().name == "Suppress")
            {
                PlayerPrefs.SetInt("trp_15", 1);
            }

            stageClear.SetActive(true);
            Text clearText = GameObject.Find("clearText").GetComponent<Text>();
            Text gainGold = GameObject.Find("gainGold").GetComponent<Text>();
            Text gainEnt = GameObject.Find("gainEnt").GetComponent<Text>();

            float stageClearEnt = 500.0f * PlayerPrefs.GetFloat("charGainEnt");

            stageClearEnt = PlayerPrefs.GetInt("Stage Ent") + stageClearEnt;
            PlayerPrefs.SetInt("Stage Ent", (int) stageClearEnt);
            float totalClearEnt = PlayerPrefs.GetInt("Total Ent") + stageClearEnt;
            PlayerPrefs.SetInt("Total Ent", (int) totalClearEnt);
            gainGold.text = "+0 G";
            Debug.Log(totalClearEnt);
            gainEnt.text = "+" + stageClearEnt + " E  >>> Total : " + totalClearEnt + " E";

            //Invoke("MainLoad", 3);
            bc.BossKill = 0;
        }
        
    }
    IEnumerator SpawnGiantRepeat()
    {
        int rand = (int)Random.Range(5, 10);
        for(int i = 0; i < totalEnemy - 1; i++)
        {
            yield return new WaitForSeconds(rand);
            SpawnEnemy();
            rand = (int)Random.Range(15, 20);
        }
    }
    IEnumerator SpawnWolfRepeat()
    {
        int rand = (int)Random.Range(5, 7);
        for (int i = 0; i < totalEnemy - 1; i++)
        {
            yield return new WaitForSeconds(rand);
            SpawnEnemy();
            rand = (int)Random.Range(5, 7);
        }
    }
    IEnumerator SpawnShellRepeat()
    {
        int rand = (int)Random.Range(7, 10);
        for (int i = 0; i < totalEnemy - 1; i++)
        {
            yield return new WaitForSeconds(rand);
            SpawnEnemy();
            rand = (int)Random.Range(10, 12);
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