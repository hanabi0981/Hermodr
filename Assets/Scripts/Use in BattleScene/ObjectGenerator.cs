using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public int killcount = 0;

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
