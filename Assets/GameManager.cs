using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int killCount = 0;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(killCount);
    }
}
