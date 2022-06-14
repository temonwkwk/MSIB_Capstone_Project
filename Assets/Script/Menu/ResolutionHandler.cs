using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionHandler : MonoBehaviour
{
    private int ResolutionWidth;
    private int ResolutionHeight;
    private bool FullscreenIsOn;

    public void SetResolutionWidth(int width) => ResolutionWidth = width;
    public void SetResolutionHeight(int height) => ResolutionHeight = height;
    public void SetFullscreen(bool value) => FullscreenIsOn = value;

    public void SetResolution()
    {
        Debug.Log(ResolutionWidth + "x" + ResolutionHeight + ", " + FullscreenIsOn);
        Screen.SetResolution(ResolutionWidth, ResolutionHeight, FullscreenIsOn);
    }
}
