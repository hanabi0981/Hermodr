using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DivineLongClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public float requiredHoldTime;
    public UnityEvent onLongClick;
    public GameObject DivineStatusPanel;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }
    private void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requiredHoldTime)
            {
                if (onLongClick != null)
                {
                    onLongClick.Invoke();
                }
            }
        }
    }
    private void Reset()
    {
        pointerDown = false;
        StatusPanelSetInActive();
        pointerDownTimer = 0;
    }
    public void StatusPanelSetActive()
    {
        DivineStatusPanel.SetActive(true);
    }
    public void StatusPanelSetInActive()
    {
        DivineStatusPanel.SetActive(false);
    }
}
