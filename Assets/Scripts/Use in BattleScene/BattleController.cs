using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject ally_object;
    public GameObject enemy_object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Keypad1))
        {
            Instantiate(ally_object);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            Instantiate(enemy_object);
        }
    }
}
