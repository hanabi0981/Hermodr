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
            // InGameShopManager�� ���������� DontDestroyOnLoad�� �����Ѵٸ�, 
            if (InGameShopManager.instance != null)
            {
                // playerItems�� sprite��, ���ŵ� sprite�� index ���� ������ ����.
                playerItems[i].GetComponent<Image>().sprite = InGameShopManager.instance.iL.ISprite[InGameShopManager.instance.HaveItemSpriteNumber[i]];
                // �ʱ���´� ���� ��Ȱ���̹Ƿ�, sprite�� ����� gameobject�� Ȱ��ȭ.
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
            Debug.Log("��������.");
        }
    }
}
