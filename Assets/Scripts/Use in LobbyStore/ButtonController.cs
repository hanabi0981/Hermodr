using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject[] lobbystore_Items = new GameObject[2];
    private ItemInfo[] lobbystore_ItemsInfo = new ItemInfo[8];
    public Sprite[] heroLists = new Sprite[8];
    private List<string> playerPrefabItemList = new List<string>() { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8" };
    private void Awake()
    {
        for (int i = 0; i < lobbystore_Items.Length; i++)
        {
            lobbystore_ItemsInfo[i] = lobbystore_Items[i].GetComponentInChildren<ItemInfo>();
        }
    }
    public void Back()
    {
        GameObject selectedHero = GameObject.FindGameObjectWithTag("Hero");
        if(selectedHero != null)
        {
            Sprite heroSprite = selectedHero.GetComponent<Image>().sprite;
            for(int i = 0; i < heroLists.Length; i++)
            {
                if(heroSprite == heroLists[i])
                {
                    PlayerPrefs.SetInt("Main Hero", i);
                }
            }
        }
        SceneManager.LoadScene("Main");
    }
    public void Buy()
    {
        GameObject selectedHero = GameObject.FindGameObjectWithTag("Purchase");
        if(selectedHero != null)
        {
            selectedHero.transform.GetChild(0).GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("Sprites/misc")[1];
            selectedHero.GetComponent<ItemInfo>().ItemSelection();
            PlayerPrefs.SetInt(selectedHero.transform.parent.name, 1);
            selectedHero.GetComponent<ItemInfo>().isHave = PlayerPrefs.GetInt(selectedHero.transform.parent.name);
        }
    }
    public void HeroReset()
    {
        for(int i = 0; i < playerPrefabItemList.Count; i++)
        {
            PlayerPrefs.DeleteKey(playerPrefabItemList[i]);
        }
        ItemInfo[] itemInfos = GameObject.FindObjectsOfType<ItemInfo>();
        for(int i = 0; i < itemInfos.Length; i++)
        {
            itemInfos[i].ToReset();
        }
        PlayerPrefs.SetInt("Main Hero", 100);
    }
}