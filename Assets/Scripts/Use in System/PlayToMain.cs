using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayToMain : MonoBehaviour
{
    public void BackToMain()
    {
        GameObject someday = GameObject.Find("TestObject");
        StageSelector.stageClear = 0;
        Destroy(someday);
        SceneManager.LoadScene("Main");
    }
}
