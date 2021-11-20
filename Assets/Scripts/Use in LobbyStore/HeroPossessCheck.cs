using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroPossessCheck : MonoBehaviour
{
    public int[] a = new int[8];
    private List<string> b = new List<string>() { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8"};
    void Start()
    {
        //ItemInfo[] heroLists = GameObject.FindObjectsOfType<ItemInfo>();
        //for(int i = 0; i < heroLists.Length; i++)
        //{
        //    Debug.Log("현재 계정의 영웅 소유 상태 : " + PlayerPrefs.GetInt(b[i]));
        //}
    }
}
