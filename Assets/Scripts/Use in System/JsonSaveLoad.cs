using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;

public class JsonSaveLoad : MonoBehaviour
{
    public Text tx;
    List<viking_unit> data = new List<viking_unit>();

    private void Start()
    {
        data.Add(new viking_unit("바이킹", 20));
        data.Add(new viking_unit("발키리", 30));
    }
    public void K_save()
    {
        string jdata = JsonConvert.SerializeObject(data);
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        string format = System.Convert.ToBase64String(bytes);

        File.WriteAllText(Application.dataPath + "", format);
    }

    public void K_Load()
    {
        string jdata = File.ReadAllText(Application.dataPath + "");
        byte[] bytes = System.Convert.FromBase64String(jdata);
        string reformat = System.Text.Encoding.UTF8.GetString(bytes);

        tx.text = jdata;
        data = JsonConvert.DeserializeObject<List<viking_unit>>(jdata);
    }

}

class viking_unit
{
    public string name;
    public int power;

    public viking_unit(string name, int power)
    {
        this.name = name;
        this.power = power;
    }
}
