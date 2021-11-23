using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCardContorller : MonoBehaviour
{
    public float drawTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > drawTime + 5.0f)
        {
            GetComponent<Button>().interactable = true;
        }
    }
}
