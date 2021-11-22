using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public AudioMixer bgm_Mixer;
    public AudioMixer sfx_Mixer;

    public Slider bgm_Slider;
    public Slider sfx_Slider;

    // Start is called before the first frame update
    void Start()
    {
        bgm_Slider.value = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
        sfx_Slider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
    }

    public void SetBGMLevel(float slider_Value)
    {
        bgm_Mixer.SetFloat("BGM", Mathf.Log10(slider_Value) * 20);
        PlayerPrefs.SetFloat("BGMVolume", slider_Value);
    }

    public void SetSFXLevel(float slider_Value)
    {
        sfx_Mixer.SetFloat("SFX", Mathf.Log10(slider_Value) * 20);
        PlayerPrefs.SetFloat("SFXVolume", slider_Value);
    }        
}
