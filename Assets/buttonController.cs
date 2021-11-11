using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonController : MonoBehaviour
{
    public void Trophy()
    {
        SceneManager.LoadScene("MythCollection");
    }

    public void Battle()
    {
        SceneManager.LoadScene("Battle");
    }
}
