using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pop_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject pop_Window;
    [SerializeField]
    public Text haveEnt;
    public void Pop_UP()
    {
        pop_Window.SetActive(true);
        PlayerPrefs.SetFloat("Total Ent", 10000);
        haveEnt.text = PlayerPrefs.GetFloat("Total Ent") + " E";
    }

    public void Pop_Down()
    {
        pop_Window.SetActive(false);
    }
}
