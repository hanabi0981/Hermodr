using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UnitJson : MonoBehaviour
{
    public UnitData unitdata;

    [ContextMenu("To Json Data")]
    void SaveUnitDataToJson()
    {
        string UnitJsonData = JsonUtility.ToJson(unitdata, true);
        string path = Path.Combine(Application.dataPath, "UnitData.json");
        File.WriteAllText(path, UnitJsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadUnitDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "UnitData.Json");
        string UnitJsonData = File.ReadAllText(path);
        unitdata = JsonUtility.FromJson<UnitData>(UnitJsonData);
    }
}


[System.Serializable]
public class UnitData
{
    public string UnitCode;
    public string UnitName;
    public int UnitHP;
    public int UnitLevel;
    public int UnitATK;
    public int UnitDEF;
    public int UnitRANGE;
    public int UnitSPEED;
    public int UnitEXP;
    public int UnitATKSPEED;
    public bool isDead;
    public string[] Unititems;
}

