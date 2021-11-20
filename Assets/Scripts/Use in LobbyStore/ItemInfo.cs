using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemInfo : MonoBehaviour
{
    public bool selected;
    public int isHave;
    public string myColor = "White";
    private void Start()
    {
        ToReset();
    }
    public void ItemSelection()
    {
       if(isHave != 1)
        {
            if (!selected)
            {
                GameObject pre_SelectedHero = GameObject.FindGameObjectWithTag("Purchase");
                if (pre_SelectedHero != null)
                {
                    pre_SelectedHero.GetComponent<ItemInfo>().ColorToNormal();
                    pre_SelectedHero.GetComponent<ItemInfo>().selected = false;
                    pre_SelectedHero.tag = "Untagged";
                }
                ColorToRed();
                this.tag = "Purchase";
                selected = true;
            }
            else
            {
                this.tag = "Untagged";
                ColorToNormal();
                selected = false;
            }
        }
        else
        {
            if(!selected)
            {
                GameObject pre_SelectedHero = GameObject.FindGameObjectWithTag("Hero");
                if (pre_SelectedHero != null)
                {
                    pre_SelectedHero.GetComponent<ItemInfo>().ColorToNormal();
                    pre_SelectedHero.GetComponent<ItemInfo>().selected = false;
                    pre_SelectedHero.tag = "Untagged";
                }
                ColorToBlue();
                this.tag = "Hero";
                selected = true;
            }
            else
            {
                this.tag = "Untagged";
                ColorToNormal();
                selected = false;
            }
        }
    }
    void ColorToNormal()
    {
        ColorBlock colorBlock = this.GetComponent<Button>().colors;
        colorBlock.normalColor = new Color(255, 255, 255, 255);
        colorBlock.selectedColor = new Color(245, 245, 245, 255);
        colorBlock.highlightedColor = new Color(245, 245, 245, 255);
        this.GetComponent<Button>().colors = colorBlock;
        myColor = "White";
    }
    void ColorToRed()
    {
        ColorBlock colorBlock = this.GetComponent<Button>().colors;
        colorBlock.normalColor = new Color(1, 0, 0, 1);
        colorBlock.selectedColor = new Color(1, 0, 0, 1);
        colorBlock.highlightedColor = new Color(245, 0, 0, 255);
        this.GetComponent<Button>().colors = colorBlock;
        myColor = "Red";
    }
    void ColorToBlue()
    {
        ColorBlock colorBlock = this.GetComponent<Button>().colors;
        colorBlock.normalColor = new Color(0, 0, 245, 255);
        colorBlock.selectedColor = new Color(0, 0, 245, 255);
        colorBlock.highlightedColor = new Color(0, 0, 245, 255);
        this.GetComponent<Button>().colors = colorBlock;
        myColor = "Blue";
    }
    public void ToReset()
    {
        Sprite[] OXSprites = Resources.LoadAll<Sprite>("Sprites/misc");
        if (PlayerPrefs.GetInt(this.transform.parent.name) == 1)
        {
            isHave = 1;
            this.transform.GetChild(0).GetComponent<Image>().sprite = OXSprites[1];
        }
        else
        {
            isHave = 0;
            this.transform.GetChild(0).GetComponent<Image>().sprite = OXSprites[0];
        }
    }
}
