using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trophy_Checker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "InGameStore")
        {
            PlayerPrefs.SetInt("trp_06", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
