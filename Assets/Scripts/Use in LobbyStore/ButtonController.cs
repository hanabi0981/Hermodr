using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject godsWindow;
    public Image mainHeroImage;
    public Image windowHeroImage;

    public GameObject[] lobbystore_Items = new GameObject[7];
    private ItemInfo[] lobbystore_ItemsInfo = new ItemInfo[7];
    public Sprite[] heroLists = new Sprite[7];
    private List<string> playerPrefabItemList = new List<string>() { "None", "GodsIcon1", "GodsIcon2", "GodsIcon3", "GodsIcon4", "GodsIcon5", "GodsIcon6" };
    private void Awake()
    {
        for (int i = 1; i < lobbystore_Items.Length; i++)
        {
            lobbystore_ItemsInfo[i] = lobbystore_Items[i].GetComponent<ItemInfo>();
        }
    }
    public void Back()
    {
        mainHeroImage.sprite = windowHeroImage.sprite;
        godsWindow.SetActive(false);
    }
    public void BuyOrSelect()
    {
        GameObject selectedHero = GameObject.FindGameObjectWithTag("Purchase");
     
        if (selectedHero != null)
        {
            DivineStatus ds = selectedHero.GetComponent<DivineLongClick>().DivineStatusPanel.GetComponent<DivineStatus>();
            Pop_Controller pc = GameObject.FindObjectOfType<Pop_Controller>().GetComponent<Pop_Controller>();
            float totalEnt = PlayerPrefs.GetFloat("Total Ent");
            if (totalEnt >= ds.divinePrice[ds.itemindex])
            {
                totalEnt -= ds.divinePrice[ds.itemindex];
                PlayerPrefs.SetFloat("Total Ent", totalEnt);
                pc.haveEnt.text = totalEnt + " E";
                selectedHero.transform.GetChild(0).GetComponent<Image>().sprite = Resources.LoadAll<Sprite>("Sprites/isHaveGods")[1];
                selectedHero.GetComponent<ItemInfo>().ItemSelection();
                PlayerPrefs.SetInt(selectedHero.name, 1);
                selectedHero.GetComponent<ItemInfo>().isHave = PlayerPrefs.GetInt(selectedHero.name);
            }  
        }
        else
        {
            selectedHero = GameObject.FindGameObjectWithTag("Hero");
            if (selectedHero != null)
            {
                Sprite heroSprite = selectedHero.GetComponent<Image>().sprite;
                selectedHero.GetComponent<ItemInfo>().ItemSelection();
                for (int i = 0; i < heroLists.Length; i++)
                {
                    if (heroSprite == heroLists[i])
                    {
                        PlayerPrefs.SetInt("Main Hero", i);
                    }
                }
            }
            windowHeroImage.sprite = heroLists[PlayerPrefs.GetInt("Main Hero")];
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
        PlayerPrefs.SetInt("Main Hero", 0);
        windowHeroImage.sprite = heroLists[PlayerPrefs.GetInt("Main Hero")];
    }
    public void ResetEnt()
    {
        Debug.Log("초기화 전 총 엔트로피 : " + PlayerPrefs.GetInt("Total Ent"));
        PlayerPrefs.SetFloat("Total Ent", 0f);
        Debug.Log("초기화 후 총 엔트로피 : " + PlayerPrefs.GetInt("Total Ent"));
    }
}