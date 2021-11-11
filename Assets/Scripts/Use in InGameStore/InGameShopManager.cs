using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameShopManager : MonoBehaviour
{
    public int[] shopItems = new int[4];
    // int count = 1;
    int c = 1;
    public float coins;
    public Text coinsText;

    public GameObject [] itemsList = new GameObject[4];
    public ItemsInfo[] IInfo = new ItemsInfo[4];
    bool[] ItemSelected = new bool[] { false, false, false, false };
    public Image[] HaveItem = new Image[4];
    // public Sprite[] ItemSprite = new Sprite[4]; 
    // Start is called before the first frame update
    void Start()
    {
        coinsText.text = coins.ToString()+ "골드";
        for(int i = 1; i <= 3; i++)
        {
            IInfo[i] = itemsList[i].GetComponent<ItemsInfo>();
        }
    }

    // Update is called once per frame
    public void Buy()
    {
        for (int i = 1; i < 4; i++)
        {
            ItemSelected[i] = IInfo[i].Selected;
            if(ItemSelected[i])
            {
                coins -= IInfo[i].price;
                coinsText.text = coins.ToString()+" 골드";
                itemsList[i].GetComponent<ItemsInfo>().ItemSelection();
                HaveItem[c++].GetComponent<Image>().sprite = IInfo[i].sprite;
            }
        }
    }
}
