using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyCheck : MonoBehaviour
{
    private int Battle = 0;
    private int Store = 0;

    public GameObject num1;
    public GameObject num2;

    public Sprite trophy1;
    public Sprite trophy2;

    private void Awake()
    {
        Battle = PlayerPrefs.GetInt("Trp_01");
        Store = PlayerPrefs.GetInt("Trp_02");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Battle==1)
        {
            num1.GetComponent<Image>().sprite = trophy1;
        }

        if (Store==1)
        {
            num2.GetComponent<Image>().sprite = trophy2;
        }
    }
}
