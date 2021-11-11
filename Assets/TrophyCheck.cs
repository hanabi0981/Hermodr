using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyCheck : MonoBehaviour
{
    public static bool Battle = false;
    public static bool Store = false;

    public GameObject num1;
    public GameObject num2;

    public Sprite trophy1;
    public Sprite trophy2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle)
        {
            num1.GetComponent<Image>().sprite = trophy1;
        }

        if (Store)
        {
            num2.GetComponent<Image>().sprite = trophy2;
        }
    }
}
