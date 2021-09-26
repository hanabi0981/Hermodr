using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JsonReadWrite : MonoBehaviour
{
    public Text HeroText;

    public void SaveToJson()
    {
        PlayerData data = new PlayerData();
        data.Hero[0] = HeroText.text;//Hero[0]

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/PlayerDataFile.json", json);
    }
    
}
