using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pop_Controller : MonoBehaviour
{
    [SerializeField]
    GameObject pop_Window;

    public void Pop_UP()
    {
        pop_Window.SetActive(true);
    }

    public void Pop_Down()
    {
        pop_Window.SetActive(false);
    }
}
