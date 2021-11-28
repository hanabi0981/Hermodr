using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGM_Player : MonoBehaviour
{
    [SerializeField]
    private string title_BGM;
    [SerializeField]
    private string main_BGM;
    [SerializeField]
    private string forest_BGM;
    [SerializeField]
    private string swamp_BGM;
    [SerializeField]
    private string hell_BGM;
    [SerializeField]
    private string dusk_BGM;
    [SerializeField]
    private string inGameStore_BGM;

    public void Title_BGM()
    {
        SoundManager.instance.PlayBGM(title_BGM);
    }

    public void Main_BGM()
    {
        SoundManager.instance.PlayBGM(main_BGM);
    }

    public void Forest_BGM()
    {
        SoundManager.instance.PlayBGM(forest_BGM);
    }

    public void Swamp_BGM()
    {
        SoundManager.instance.PlayBGM(swamp_BGM);
    }

    public void Hell_BGM()
    {
        SoundManager.instance.PlayBGM(hell_BGM);
    }

    public void Dusk_BGM()
    {
        SoundManager.instance.PlayBGM(dusk_BGM);
    }
    public void InGameStore_BGM()
    {
        SoundManager.instance.PlayBGM(inGameStore_BGM);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        BGM_Select();
    }
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void BGM_Select()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Title_BGM();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Main_BGM();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Forest_BGM();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            Swamp_BGM();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            Hell_BGM();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            Dusk_BGM();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            InGameStore_BGM();
        }
        else if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            Dusk_BGM();
        }
    }
}
