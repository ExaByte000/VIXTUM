using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using UnityEngine.UIElements;
using UnityEngine.UI;
using System;

public class MusicSettings : MonoBehaviour
{
    private Bus backgroundMusic;
    private Bus stepsSounds;
    private UnityEngine.UI.Slider slider;
    private void Awake()
    {
        backgroundMusic = RuntimeManager.GetBus("bus:/Music");
        stepsSounds = RuntimeManager.GetBus("bus:/Sounds");
        slider = GetComponent<UnityEngine.UI.Slider>();
        
    }

    void OnEnable()
    {
        if (slider.name == "MusicSlider")
        {
            backgroundMusic.getVolume(out float volume);
            slider.value = volume;
        }
        else if (slider.name == "SoundsSlider")
        {
            stepsSounds.getVolume(out float volume);
            slider.value = volume;
        }
    }

    public void SetVolume()
    {
        Debug.Log(slider.name);
        switch (slider.name)
        {
            case "MusicSlider":
                backgroundMusic.setVolume(slider.value);
                break;
            case "SoundsSlider":
                stepsSounds.setVolume(slider.value);
                break;
        }

    }

}
