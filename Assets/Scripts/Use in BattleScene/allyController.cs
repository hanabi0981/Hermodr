using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allyController : MonoBehaviour
{
    int speed = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        transform.Translate(0.01f * speed, 0, 0);
    }

   
}
