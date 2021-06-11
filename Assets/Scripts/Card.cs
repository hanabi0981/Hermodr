using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Card : MonoBehaviour
{
    [SerializeField] SpriteRenderer card;
    [SerializeField] SpriteRenderer character;
    [SerializeField] TMP_Text nameTMP;
    [SerializeField] TMP_Text valueTMP;
    [SerializeField] Sprite cardHead;
    [SerializeField] Sprite cardTail;

    public Item item;
    bool isFront;
    public PRS originPRS;

    public void Setup(Item item, bool isFront)
    {
        this.item = item;
        this.isFront = isFront;

        if (this.isFront)
        {
            character.sprite = this.item.sprite;
            nameTMP.text = this.item.name;
            valueTMP.text = this.item.value.ToString();            
        }
        else
        {
            card.sprite = cardTail;
        }
    }

    void OnMouseOver()
    {
        if (isFront)
            CardManager.Inst.CardMouseOver(this);
    }
    void OnMouseExit()
    {
        if (isFront)
            CardManager.Inst.CardMouseExit(this);
    }
    void OnMouseDown()
    {
        if (isFront)
            CardManager.Inst.CardMouseDown();
    }
    void OnMouseUp()
    {
        if (isFront)
            CardManager.Inst.CardMouseUp();
        Transform tr = CardManager.selectCard.transform.Find("Character");
        string codeN = tr.GetComponent<SpriteRenderer>().sprite.name;

        if (CardManager.selectCard.transform.position.y > 1)
            switch (codeN)
            {
                case "card001":
                    Debug.Log(001);
                    //                    CardManager.selectCard.Remove(card);
                    CardManager.selectCard.gameObject.SetActive(false);
                    CardManager.selectCard = null;

                    break;
                case "card002": Debug.Log(002); DestroyImmediate(CardManager.selectCard.gameObject); break;
                case "card003": Debug.Log(003); DestroyImmediate(CardManager.selectCard.gameObject); break;
                case "card004": Debug.Log(004); DestroyImmediate(CardManager.selectCard.gameObject); break;
                case "card005": Debug.Log(005); DestroyImmediate(CardManager.selectCard.gameObject); break;
            }
    }

    public void MoveTransform(PRS prs, bool useDotween, float dotweenTime = 0)
    {
        if (useDotween)
        {
            transform.DOMove(prs.pos, dotweenTime);
            transform.DORotateQuaternion(prs.rot, dotweenTime);
            transform.DOScale(prs.scale, dotweenTime);
        }
        else
        {
            transform.position = prs.pos;
            transform.rotation = prs.rot;
            transform.localScale = prs.scale;
        }
    }
}
