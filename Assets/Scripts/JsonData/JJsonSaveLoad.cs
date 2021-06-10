using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.UI;
using System.IO;

public class JJsonSaveLoad : MonoBehaviour
{
    public Text tx;
    List<unit> data = new List<unit>();

    private void Start()
    {
        data.Add(new unit("바이킹", 20));
        data.Add(new unit("발키리", 30));
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
        data = JsonConvert.DeserializeObject<List<unit>>(jdata);
    }

}

class unit
{
    public string name;
    public int power;

    public unit(string name, int power)
    {
        this.name = name;
        this.power = power;
    }
}
