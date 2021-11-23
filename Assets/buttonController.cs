using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    public List<int> stageIndex = new List<int>() { 2, 3, 4 };
    public int[] stageOrders;
    int stageNumbers;

    private void Start()
    {
        stageNumbers = stageIndex.Count;
        stageOrders = new int[3];
    }
    public void Trophy()
    {
        SceneManager.LoadScene("MythCollection");
    }

    public void Battle()
    {
        // 메인 영웅의 스프라이트에 따라 신성 능력 부여
        DivineStatus ds = GetComponent<DivineStatus>();
        
        for (int i = 0; i < ds.divineSprite.Length; i++)
        {
            if (GameManager.instance.mainHeroImage.sprite == ds.divineSprite[i])
            {
                Debug.Log("몇번째? :" + i);
                ds.DivineAblilty(i);
            }
        }
        StartCoroutine(Delay());       

        // SceneManager.LoadScene("Battle");
    }
    public void Test()
    {
        SceneManager.LoadScene("Test");
    }
    public void TestStore()
    {
        //InGameShopManager.isSolo = false;
        //GameObject inGameShopManager = GameObject.Find("InGameShopManager");
        //DontDestroyOnLoad(inGameShopManager);
        SceneManager.LoadScene("Test");
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.75f);

        for (int i = 0; i < stageNumbers; i++)
        {
            int rand = Random.Range(0, stageIndex.Count);
            stageOrders[i] = stageIndex[rand];
            //Debug.Log(stageOrders[i] - 2);
            stageIndex.RemoveAt(rand);
        }
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("Test");
    }
}
