using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InGameShopManager : MonoBehaviour
{
    public static InGameShopManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<InGameShopManager>();
            }
            return m_instance;
        }
    }
    private static InGameShopManager m_instance;
    public static bool isSolo = true;
    public int[] shopItems = new int[4];
    public static int c = 1;
    public static float coins = 1000;
    public static float usedCoins = 0;
    public Text coinsText;

    public GameObject[] itemsList = new GameObject[4];
    public ItemsInfo[] IInfo = new ItemsInfo[4];
    public bool[] ItemSelected = new bool[] { false, false, false, false };
    public GameObject[] HaveItem = new GameObject[6];
    public int[] HaveItemSpriteNumber = new int[6];
    public static int b = 0;
    public ItemsList iL;

    public static List<string> HaveItemSpriteNumber2 = new List<string>() {"None", "Item_01", "Item_02", "Item_03", "Item_04", "Item_05" };
    public static List<string> HaveItemForgeNumber = new List<string>() { "None", "F_Item_01", "F_Item_02", "F_Item_03", "F_Item_04", "F_Item_05" };
    public GameObject buyButton;

    public int forgeChance;
    int charForgeChance = 1;
    public Button forgeButton;
    public GameObject player;
    // Start is called before the first frame update   
    void Start()
    {
        coinsText.text = "Coins : " + coins.ToString();
        for (int i = 1; i <= 3; i++)
        {
            IInfo[i] = itemsList[i].GetComponent<ItemsInfo>();
        }
        iL = GetComponent<ItemsList>();
        if(!isSolo)
        {
            gameObject.SetActive(false);
        }
        for(int i = 1; i < HaveItemSpriteNumber2.Count; i++)
        {
            HaveItem[i].GetComponent<Image>().sprite = iL.ISprite[PlayerPrefs.GetInt(HaveItemSpriteNumber2[i])];
        }
        // 강화 횟수 제한 (기본적으로 1번)
        forgeButton.interactable = true;
        forgeChance = charForgeChance;
        for(int i = 1; i < HaveItem.Length; i++)
        {
            HaveItem[i].GetComponentInChildren<Text>().text = "+" + PlayerPrefs.GetInt(HaveItemForgeNumber[i]);
        }
        // 플레이어 프리팹 초기화
        player.GetComponent<PlayerCombat>().startHealth = 100.0f;
        player.GetComponent<PlayerCombat>().moveSpeed = 1.0f;
        player.GetComponent<PlayerCombat>().damage = 25.0f;
        player.GetComponent<PlayerCombat>().attackRange = 0.6f;
        player.GetComponent<PlayerCombat>().timeBetAttack = 1.0f;
    }
    public void Buy()
    {
        for (int i = 1; i < 4; i++)
        {
            if(c <= 5)
            {
                ItemSelected[i] = IInfo[i].Selected;
                if (ItemSelected[i])
                {
                    if (coins - IInfo[i].price >= 0)
                    {
                        coins -= IInfo[i].price;
                        coinsText.text = "GOLD : " + coins.ToString();
                        itemsList[i].GetComponent<ItemsInfo>().ItemSelection();
                        PlayerPrefs.SetInt(HaveItemSpriteNumber2[c], itemsList[i].GetComponent<ItemsInfo>().value);
                        // Debug.Log("선택한 아이템의 ISprite 번호 : " + PlayerPrefs.GetInt(HaveItemSpriteNumber2[c]));
                        HaveItem[c].GetComponent<Image>().sprite = IInfo[i].sprite;
                        c++;

                        // counting coins that used for buy
                        usedCoins += IInfo[i].price;

                    }
                }
            }
            else
            {
                buyButton.GetComponent<Button>().interactable = false;
            }
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene("Battle");
        //DontDestroyOnLoad(gameObject);
    }
    public void ForgeItem()
    {
        GameObject Forge_SelectedItem = GameObject.FindGameObjectWithTag("Forge");
        int targetNumber = 0;
        for(int i = 1; i < HaveItem.Length; i++)
        {
            if(HaveItem[i].name == Forge_SelectedItem.name)
            {
                targetNumber = i;
            }
        }
        int forgeValue = int.Parse(Forge_SelectedItem.GetComponentInChildren<Text>().text.ToString().Substring(1));
        if (forgeValue < 2)
        {
            forgeValue++;
            forgeChance--;
            PlayerPrefs.SetInt(HaveItemForgeNumber[targetNumber], forgeValue);
            Forge_SelectedItem.GetComponentInChildren<Text>().text = "+" + forgeValue;
            Forge_SelectedItem.GetComponent<HaveItemsInfo>().ItemSelection();
            Debug.Log(forgeValue);
        }
        if(forgeChance <= 0)
        {
            forgeButton.interactable = false;
        }
    }
}