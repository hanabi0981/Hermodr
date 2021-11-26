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
        haveEnt.text = PlayerPrefs.GetInt("Total Ent") + " E";
    }

    public void Pop_Down()
    {
        pop_Window.SetActive(false);
    }
}
