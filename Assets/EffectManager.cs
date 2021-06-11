using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject en01;
    public GameObject en02;
    public GameObject en03;
    public GameObject en04;
    public GameObject en05;
    public GameObject viking;

    Transform ePos;
    private void Start()
    {
        
    }

    private void Update()
    {
        Vector2 ePos = new Vector2(5.2f, -2.7f);
        Vector2 tPos = new Vector2(-5.2f, -2.7f);
        Vector2 vPos = new Vector2(-2.9f, -1.4f);
        Vector2 bPos = new Vector2(5.2f, -1f);

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            Instantiate(en01, vPos, Quaternion.identity);
            Instantiate(viking, vPos, Utils.QI);
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
            Instantiate(en02, ePos, Quaternion.identity);
        else if (Input.GetKeyDown(KeyCode.Keypad6))
            Instantiate(en03, tPos, Quaternion.identity);
        else if (Input.GetKeyDown(KeyCode.Keypad7))
            Instantiate(en04, ePos, Quaternion.identity);
        else if (Input.GetKeyDown(KeyCode.Keypad8))
            Instantiate(en05, bPos, Quaternion.identity);


    }
}
