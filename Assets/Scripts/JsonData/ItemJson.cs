using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemJson : MonoBehaviour
{
    public ItemData itemdata;

    [ContextMenu("To Json Data")]
    void SaveUnitDataToJson()
    {
        string ItemJsonData = JsonUtility.ToJson(itemdata, true);
        string path = Path.Combine(Application.dataPath, "ItemData.json");
        File.WriteAllText(path, ItemJsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadUnitDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "ItemData.Json");
        string ItemJsonData = File.ReadAllText(path);
        itemdata = JsonUtility.FromJson<ItemData>(ItemJsonData);
    }
}


[System.Serializable]
public class ItemData
{
    public string ItemCode;
    public string ItemName;
    public int ItemHP;
    public int ItemLevel;
    public int ItemATK;
    public int ItemDEF;
    public int ItemSPEED;
    public int ItemEXP;
    public int ItemATKSPEED;
}