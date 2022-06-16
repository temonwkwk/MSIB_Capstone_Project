using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameSettings : MonoBehaviour
{
    private int ResolutionWidth;
    private int ResolutionHeight;
    private bool FullscreenIsOn;

    public void SetResolutionWidth(int width) => ResolutionWidth = width;
    public void SetResolutionHeight(int height) => ResolutionHeight = height;
    public void SetFullscreen(bool value) => FullscreenIsOn = value;

    public AudioMixer audioMixer;

    public void SetResolution()
    {
        Debug.Log(ResolutionWidth + "x" + ResolutionHeight + ", " + FullscreenIsOn);
        Screen.SetResolution(ResolutionWidth, ResolutionHeight, FullscreenIsOn);
    }

    public void SetVSync(int value)
    {
        Debug.Log("VSync : " + value);
        QualitySettings.vSyncCount = value;
    }

    public void SetQuality(int value)
    {
        Debug.Log("Graphic : " + value);
        QualitySettings.SetQualityLevel(value, true);
    }

    public void SetAntiAliasing(int value)
    {
        Debug.Log("Anti Aliasing : " + value);
        QualitySettings.antiAliasing = value;
    }

    public void SetBGM (float volume)
    {
        audioMixer.SetFloat("BGMVol", volume);
    }

    public void SetSFX (float volume)
    {
        audioMixer.SetFloat("SFXVol", volume);
    }
}
