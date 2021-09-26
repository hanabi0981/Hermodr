using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JsonWrite : MonoBehaviour
{
    public Text nText;
    public void LoadToJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/PlayerDataFile.Json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);

        nText.text = data.Id;
    }
}
