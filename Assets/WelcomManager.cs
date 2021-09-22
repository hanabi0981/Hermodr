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
       
            string json = File.ReadAllText(Application.dataPath + "/LoginData.Json");
            LoginData data = JsonUtility.FromJson<LoginData>(json);

            nText.text = data.NickName;
        
            popUp.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            popUp.gameObject.SetActive(false);
    }

    
}
