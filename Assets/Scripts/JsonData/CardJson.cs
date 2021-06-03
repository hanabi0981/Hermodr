using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CardJson : MonoBehaviour
{
    public CardData carddata;

    [ContextMenu("To Json Data")]
    void SaveUnitDataToJson()
    {
        string CardJsonData = JsonUtility.ToJson(carddata, true);
        string path = Path.Combine(Application.dataPath, "CardData.json");
        File.WriteAllText(path, CardJsonData);
    }

    [ContextMenu("From Json Data")]
    void LoadUnitDataToJson()
    {
        string path = Path.Combine(Application.dataPath, "CardData.Json");
        string CardJsonData = File.ReadAllText(path);
        carddata = JsonUtility.FromJson<CardData>(CardJsonData);
    }
}


[System.Serializable]
public class CardData
{
    public string CardCode;
    public string CardName;
    public string CardExplain;
    public int CardRune;
    public int Cardgem;
    public int CardDamage;
    public int CardHeal;
}
