using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Button : MonoBehaviour
{
    [SerializeField]
    private string button_Sound;
    [SerializeField]
    private string battle_Sound;

    public void Button_Sound()
    {
        SoundManager.instance.PlaySE(button_Sound);
    }

    public void Battle_Sound()
    {
        SoundManager.instance.PlaySE(battle_Sound);

    }
}
