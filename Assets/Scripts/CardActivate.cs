using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActivate : MonoBehaviour
{
    public bool isActivate;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("true");
       isActivate = true;
    }
}
