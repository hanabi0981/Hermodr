using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToNext : MonoBehaviour
{

   public void ToNextScene()
    {
        SceneManager.LoadScene("InGameStore");
    }
    public void ToMainScene()
    {
        SceneManager.LoadScene("Main");
    }
}
