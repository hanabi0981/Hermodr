using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileBack : MonoBehaviour
{
    int touchCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            touchCount++;
            if (!IsInvoking("DoubleTouch"))
                Invoke("DoubleTouch", 1.0f);
        }
        else if(touchCount == 2)
        {
            CancelInvoke("DoubleTouch");
            PlayerPrefs.Save();
            Application.Quit();
        }
    }

    void DoubleTouch()
    {
        touchCount = 0;
    }
}
