using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeChoiceButton : MonoBehaviour
{
    // 스토리모드 버튼 터치 -> 스토리모드 입장
    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
