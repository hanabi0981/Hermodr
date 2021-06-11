using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using System.IO;

public class WelcomManager : MonoBehaviour
{
    public GameObject popUp;
    public Text nText;

    // Start is called before the first frame update
    void Start()
    {
        popUp.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            popUp.gameObject.SetActive(false);
    }

    public void LoadNickName()
    {
        string nickname = File.ReadAllText(Application.dataPath + "/LoginData.Json");
        byte[] bytes = System.Convert.FromBase64String(nickname);
        string reformat = System.Text.Encoding.UTF8.GetString(bytes);

        nText.text = nickname;
    }
}
