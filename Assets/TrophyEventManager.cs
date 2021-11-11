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
        if(SceneManager.GetActiveScene().buildIndex == 2)
        {
            TrophyCheck.Battle = true;
        }

        if(SceneManager.GetActiveScene().buildIndex == 3)
        {
            TrophyCheck.Store = true;
        }

        if(Input.GetKeyDown(KeyCode.Keypad4))
        {
            SceneManager.LoadScene("InGameStore");
        }
    }
}
