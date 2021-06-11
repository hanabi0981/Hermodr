using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class LoginSaveLoad : MonoBehaviour
{
    public InputField NickNameInputField;

    public void SaveToJson()
    {
        LoginData data = new LoginData();
        data.NickName = NickNameInputField.text;

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(Application.dataPath + "/LoginData.Json", json);
    }

    public void LoadToJson()
    {
        string json = File.ReadAllText(Application.dataPath + "/LoginData.Json");
        LoginData data = JsonUtility.FromJson<LoginData>(json);

        NickNameInputField.text = data.NickName;
    }

}
