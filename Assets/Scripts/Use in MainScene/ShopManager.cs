using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[15, 15];
    int count = 1;
    public float coins;
    public Text coinsText;
    public GameObject shop;

    // Start is called before the first frame update
    void Start()
    {
        shop.SetActive(false);

        coinsText.text = "Coins : " + coins.ToString();

        // ID
        while (count < shopItems.GetLength(0))
        {
            shopItems[1, count] = count;
            count++;
        }
        count = 1;

        // Price
        while (count < shopItems.GetLength(0))
        {
            shopItems[2, count] = 10 * count;
            count++;
        }
        count = 1;

        // Quantity
        while (count < shopItems.GetLength(0))
        {
            shopItems[3, count++] = 0;
        }

        for (int i = 0; i < InGameShopManager.HaveItemSpriteNumber2.Count; i++)
        {
            PlayerPrefs.DeleteKey(InGameShopManager.HaveItemSpriteNumber2[i]);
            PlayerPrefs.SetInt(InGameShopManager.HaveItemSpriteNumber2[i], 0);
        }
    }

    // Update is called once per frame
    public void Buy()
    {
        // 클릭한 버튼의 정보 받기
        GameObject ButtonRef = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject;


        // 구매 알고리즘
        if (coins >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            coinsText.text = "GOLD : " + coins.ToString();

            ButtonRef.GetComponent<ButtonInfo>().QuantityText.text = shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
}
