using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suppress_Edit : MonoBehaviour
{
    public GameObject endWindow;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            endWindow.SetActive(true);
        }

    }
}
