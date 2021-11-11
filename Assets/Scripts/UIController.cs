using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject popup_window;


    public void Popup_window()
    {
        popup_window.SetActive(true);
    }

    public void Close_window()
    {
        popup_window.SetActive(false);
    }
}
