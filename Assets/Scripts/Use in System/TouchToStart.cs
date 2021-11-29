using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchToStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public void onClick()
    {
        PlayerPrefs.SetInt("trp_01", 1);

        if (PlayerPrefs.GetInt("Tutorial_Step") == 0)
        {
            //SceneManager.LoadScene("Tutorial");
            PlayerPrefs.SetInt("Tutorial_Step", 1);
        }
        else if (PlayerPrefs.GetInt("Tutorial_Step") == 1)
        {
            SceneManager.LoadScene("Main");
        }
    }
}
