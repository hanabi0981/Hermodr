using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name;
    public int value;
    public Sprite sprite;
    public float percent;
}

[CreateAssetMenu(fileName ="ItemSO", menuName ="Scriptable Object/ItemSO")]
public class ItemSO : ScriptableObject
{
    public Item[] items;
}
