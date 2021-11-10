using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleGameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject[] playerItems = new GameObject[6];
    public int killcount = 0;

    private void Start()
    {
        for(int i = 1; i < playerItems.Length; i++)
        {
            // InGameShopManager가 정상적으로 DontDestroyOnLoad에 존재한다면, 
            if (InGameShopManager.instance != null)
            {
                // playerItems의 sprite를, 구매된 sprite의 index 값을 가져와 설정.
                playerItems[i].GetComponent<Image>().sprite = InGameShopManager.instance.iL.ISprite[InGameShopManager.instance.HaveItemSpriteNumber[i]];
                // 초기상태는 전부 비활성이므로, sprite가 변경된 gameobject만 활성화.
                if(playerItems[i].GetComponent<Image>().sprite != null)
                {
                    playerItems[i].SetActive(true);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            Instantiate(player);
        }
        if(Input.GetKeyDown(KeyCode.Keypad2))
        {
            Instantiate(enemy);
        }
        if(killcount >= 2)
        {
            Debug.Log("게임종료.");
        }
    }
}
