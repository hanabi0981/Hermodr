using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrophyManager : MonoBehaviour
{
    public Image[] trophyIconsButton = new Image[16];
    public Sprite[] trophyIconsSprite = new Sprite[16];

    public GameObject trophyGroup;
    public void Tropy_PopUP()
    {
        trophyGroup.SetActive(true);
        TrophyCheck();
    }

    void TrophyCheck()
    {
        // 업적 01번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[0].sprite = trophyIconsSprite[0];
        }
        // 업적 02번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[1].sprite = trophyIconsSprite[1];
        }
        // 업적 03번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[2].sprite = trophyIconsSprite[2];
        }
        // 업적 04번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[3].sprite = trophyIconsSprite[3];
        }
        // 업적 05번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[4].sprite = trophyIconsSprite[4];
        }
        // 업적 06번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[5].sprite = trophyIconsSprite[5];
        }
        // 업적 07번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[6].sprite = trophyIconsSprite[6];
        }
        // 업적 08번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[7].sprite = trophyIconsSprite[7];
        }
        // 업적 09번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[8].sprite = trophyIconsSprite[8];
        }
        // 업적 10번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[9].sprite = trophyIconsSprite[9];
        }
        // 업적 11번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[10].sprite = trophyIconsSprite[10];
        }
        // 업적 12번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[11].sprite = trophyIconsSprite[11];
        }
        // 업적 13번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[12].sprite = trophyIconsSprite[12];
        }
        // 업적 14번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[13].sprite = trophyIconsSprite[13];
        }
        // 업적 15번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[14].sprite = trophyIconsSprite[14];
        }
        // 업적 16번
        if (PlayerPrefs.GetInt("") == 0)
        {
            trophyIconsButton[15].sprite = trophyIconsSprite[15];
        }
    }
}
