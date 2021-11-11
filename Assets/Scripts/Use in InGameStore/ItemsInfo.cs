using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsInfo : MonoBehaviour
{
    public int ItemID;
    public Text PriceText;
    public GameObject ShopManager;
    int value;
    public Sprite sprite;
    public int price;
    public bool Selected;

    ItemsList Itemslist;

    // Start is called before the first frame update
    void Start()
    {
        Itemslist = ShopManager.GetComponent<ItemsList>();
        value = Random.Range(1, 11);
        sprite = Itemslist.ISprite[value];
        GetComponent<Image>().sprite = sprite;
        price = Itemslist.IPrice[value];
        PriceText.text =  price.ToString() + " 골드";

    }
    public void ItemSelection()
    {
        if (!Selected)
        {
            ColorBlock colorBlock = this.GetComponent<Button>().colors;
            colorBlock.normalColor = new Color(1, 0, 0, 1);
            colorBlock.selectedColor = new Color(1, 0, 0, 1);
            colorBlock.highlightedColor = new Color(245, 0, 0, 255);
            this.GetComponent<Button>().colors = colorBlock;
            Selected = true;
        }
        else
        {
            ColorBlock colorBlock = this.GetComponent<Button>().colors;
            colorBlock.normalColor = new Color(255, 255, 255, 255);
            colorBlock.selectedColor = new Color(245, 245, 245, 255);
            colorBlock.highlightedColor = new Color(245, 245, 245, 255);
            this.GetComponent<Button>().colors = colorBlock;
            Selected = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
       // PriceText.text = ShopManager.GetComponent<InGameShopManager>().shopItems[2, ItemID].ToString() + " G";
    }
}
