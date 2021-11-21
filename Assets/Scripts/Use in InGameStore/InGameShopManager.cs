using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

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
    public GameObject buyButton;
    // public Sprite[] ItemSprite = new Sprite[4]; 
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
        // 플레이어 프리팹 초기화
        GameObject _object = PrefabUtility.LoadPrefabContents("Assets/Prefabs/Player 1.prefab");
        _object.GetComponent<PlayerCombat>().damage = 25.0f;
        PrefabUtility.SaveAsPrefabAsset(_object, "Assets/Prefabs/Player 1.prefab");
        PrefabUtility.UnloadPrefabContents(_object);
    }

    // Update is called once per frame
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
}