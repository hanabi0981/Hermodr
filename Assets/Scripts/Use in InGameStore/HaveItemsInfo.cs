using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HaveItemsInfo : MonoBehaviour
{
    public bool selected;
    public string myColor = "White";
    public void ItemSelection()
    {
        if (!selected)
        {
            GameObject pre_SelectedItem = GameObject.FindGameObjectWithTag("Forge");
            if (pre_SelectedItem != null)
            {
                pre_SelectedItem.GetComponent<HaveItemsInfo>().ColorToNormal();
                pre_SelectedItem.GetComponent<HaveItemsInfo>().selected = false;
                pre_SelectedItem.tag = "Untagged";
            }
            ColorToRed();
            this.tag = "Forge";
            selected = true;
        }
        else
        {
            ColorToNormal();
            this.tag = "Untagged";
            selected = false;
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
}
