using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainEnemy : MonoBehaviour
{
    Text remainText;
    ObjectGenerator og;
    // Start is called before the first frame update
    void Start()
    {
        remainText = GetComponent<Text>();
        og = GameObject.FindObjectOfType<ObjectGenerator>().GetComponent<ObjectGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        remainText.text = "남은 적 : " + og.remainEnemy.ToString();
    }
}
