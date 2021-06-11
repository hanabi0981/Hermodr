using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] SpriteRenderer entity;

    public int value;
    public int attack;

    public void Setup(Item item)
    {
        value = item.value;

        this.item = item;
    }
}
