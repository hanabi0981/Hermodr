using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    public GameObject[] playerItems = new GameObject[6];

    // Start is called before the first frame update
    void Start()
    {
        /* for (int i = 1; i < playerItems.Length; i++)
        {
            // InGameShopManager가 정상적으로 DontDestroyOnLoad에 존재한다면, 
            if (InGameShopManager.instance != null)
            {
                if (InGameShopManager.instance.HaveItemSpriteNumber[i] != 0)
                {
                    // playerItems의 sprite를, 구매된 sprite의 index 값을 가져와 설정.
                    playerItems[i].GetComponent<Image>().sprite = InGameShopManager.instance.iL.ISprite[InGameShopManager.instance.HaveItemSpriteNumber[i]];
                    // 초기상태는 전부 비활성이므로, sprite가 변경된 gameobject만 활성화.
                    if (playerItems[i].GetComponent<Image>().sprite != null)
                    {
                        playerItems[i].SetActive(true);
                    }
                }
            }
        } */

        for (int i = 1; i < 6; i++)
        {
            if(InGameShopManager.instance.HaveItemSpriteNumber[i] != 0)
            {
                InGameShopManager.c++;
            }
        }
    }
}
