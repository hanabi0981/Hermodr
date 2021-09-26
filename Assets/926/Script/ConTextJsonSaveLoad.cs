using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ConTextJsonSaveLoad : MonoBehaviour
{
    public PlayerData playerdata;

    [ContextMenu("To Json Data")]
    void SaveToJson()
    {
        string jsonData = JsonUtility.ToJson(playerdata, true);
        string path = Path.Combine(Application.dataPath, "PlayerDataFile.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("From Json Data")]
    void LoadToJson()
    {
        string path = Path.Combine(Application.dataPath, "PlayerDataFile.Json");
        string jsonData = File.ReadAllText(path);
        playerdata = JsonUtility.FromJson<PlayerData>(jsonData);
    }


}
