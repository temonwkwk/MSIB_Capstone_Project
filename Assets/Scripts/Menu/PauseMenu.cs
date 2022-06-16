using System.Collections;
using System.Collections.Generic;
using SlimUI.ModernMenu;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject Background;
    public GameObject pauseMenuCanvas;

    private bool isActive;

    public enum Theme { custom1, custom2, custom3 };
    [Header("Theme Settings")]
    public Theme theme;
    int themeIndex;
    public FlexibleUIData themeController;

    void Start()
    {
        SetThemeColors();
    }

    void SetThemeColors()
    {
        if (theme == Theme.custom1)
        {
            themeController.currentColor = themeController.custom1.graphic1;
            themeController.textColor = themeController.custom1.text1;
            themeIndex = 0;
        }
        else if (theme == Theme.custom2)
        {
            themeController.currentColor = themeController.custom2.graphic2;
            themeController.textColor = themeController.custom2.text2;
            themeIndex = 1;
        }
        else if (theme == Theme.custom3)
        {
            themeController.currentColor = themeController.custom3.graphic3;
            themeController.textColor = themeController.custom3.text3;
            themeIndex = 2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {            
            if (!isActive)
            {
                Time.timeScale = 0;
                Background.SetActive(true);
                pauseMenuCanvas.SetActive(true);
                isActive = true;
            }
            else if (isActive)
            {
                returntogame();
            }
        }
    }

    public void returntogame()
    {
        Time.timeScale = 1;
        Background.SetActive(false);
        pauseMenuCanvas.SetActive(false);
        isActive = false;
    }
}
