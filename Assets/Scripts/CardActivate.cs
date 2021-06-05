using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActivate : MonoBehaviour
{
    public bool isActivate=false;

    
    public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("stay");
        isActivate = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("exit");
        isActivate = false;
    }
}
