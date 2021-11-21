using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelector : MonoBehaviour
{
    public Sprite[] stageSprite = new Sprite[3]; 
    public GameObject[] stageObject = new GameObject[3];
    public static int stageClear;
    buttonController bc;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("클리어 한 스테이지 갯수 : " + stageClear);
        StartCoroutine(StageSelect());
    }

    IEnumerator StageSelect()
    {
        bc = GameObject.Find("TestObject").GetComponent<buttonController>();
        for (int i = 0; i < stageObject.Length; i++)
        {
            stageObject[i].GetComponent<Image>().sprite = stageSprite[bc.stageOrders[i] - 2];
        }

        yield return new WaitForSeconds(3f);

        if (stageClear != 3)
        {
            SceneManager.LoadScene(bc.stageOrders[stageClear++]);
        }
        else
        {
            SceneManager.LoadScene("Battle");
        }
    }
}
