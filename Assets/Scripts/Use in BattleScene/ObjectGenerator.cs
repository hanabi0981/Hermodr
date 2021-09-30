using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

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
    }
}
