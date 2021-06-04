using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject popup_mission;

    public void Popup_mission()
    {
        popup_mission.SetActive(true);
    }

    public void Close_mission()
    {
        popup_mission.SetActive(false);
    }
}
