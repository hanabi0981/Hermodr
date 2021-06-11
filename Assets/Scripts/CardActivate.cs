using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActivate : MonoBehaviour
{
    public bool isActivate=false;

    public Collider2D target = null;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (target == null)
        {
            target = collision;
        }

        target.GetComponentInParent<SpriteOutline>().color = Color.red;

        isActivate = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        target.GetComponentInParent<SpriteOutline>().color = Color.black;

        if (target == collision)
        {
            target = null;
        }
        
        isActivate = false;
    }
}
