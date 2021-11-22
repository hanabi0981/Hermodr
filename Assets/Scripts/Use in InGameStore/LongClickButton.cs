using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public float requiredHoldTime;
    public UnityEvent onLongClick;
    public GameObject ItemStatusPanel;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        Debug.Log("롱클릭 이벤트 발생");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        Debug.Log("롱클릭 이벤트 끝");
    }
    private void Update()
    {
        if(pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer >= requiredHoldTime)
            {
                if(onLongClick != null && this.GetComponent<Image>().sprite.name != "UI002_116")
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
        Debug.Log(ItemStatusPanel.transform.GetChild(0).gameObject.name);
        ItemStatusPanel.SetActive(true);
    }
    public void StatusPanelSetInActive()
    {
        ItemStatusPanel.SetActive(false);
    }
}
