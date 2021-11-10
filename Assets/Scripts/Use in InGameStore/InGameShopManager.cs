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

    public int[] shopItems = new int[4];
    int c = 1;
    public float coins;
    public Text coinsText;

    public GameObject [] itemsList = new GameObject[4];
    public ItemsInfo[] IInfo = new ItemsInfo[4];
    public bool[] ItemSelected = new bool[] { false, false, false, false };
    public GameObject[] HaveItem = new GameObject[6];
    public int[] HaveItemSpriteNumber = new int[6];
    int b = 1;
    public ItemsList iL;
    // public Sprite[] ItemSprite = new Sprite[4]; 
    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = "Coins : " + coins.ToString();
        for(int i = 1; i <= 3; i++)
        {
            IInfo[i] = itemsList[i].GetComponent<ItemsInfo>();
        }
        iL = GetComponent<ItemsList>();
    }

    // Update is called once per frame
    public void Buy()
    {
        for (int i = 1; i < 4; i++)
        {
            ItemSelected[i] = IInfo[i].Selected;
            if(ItemSelected[i])
            {
                if (coins - IInfo[i].price >= 0)
                {
                    coins -= IInfo[i].price;
                    coinsText.text = "GOLD : " + coins.ToString();
                    itemsList[i].GetComponent<ItemsInfo>().ItemSelection();
                    HaveItem[c].GetComponent<Image>().sprite = IInfo[i].sprite;
                    // itemList의 Sprite 갯수만큼 반복.
                    for(int j = 1; j < iL.ISprite.Length; j++)
                    {
                        // 현재 HaveItem에 들어간 sprite의 ISprite Index 값을 가져옴.
                        if(iL.ISprite[j] == HaveItem[c].GetComponent<Image>().sprite)
                        {
                            HaveItemSpriteNumber[b] = j;
                            b++;
                        }
                    }
                    c++;
                }
            }
        }
    }
    public void Exit()
    {
        SceneManager.LoadScene("Battle");
        DontDestroyOnLoad(gameObject);
    }
}
