using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyEventManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 2 || SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4 || SceneManager.GetActiveScene().buildIndex == 5)
        {
            PlayerPrefs.SetInt("Trp_01", 1);
        }

        if(SceneManager.GetActiveScene().buildIndex == 7)
        {
            PlayerPrefs.SetInt("Trp_02", 1);
        }

        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            SceneManager.LoadScene("InGameStore");
        }
    }
}
