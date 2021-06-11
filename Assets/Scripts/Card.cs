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

        if (CardManager.selectCard.transform.position.y > -2)
            DestroyImmediate(CardManager.selectCard.gameObject);
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
