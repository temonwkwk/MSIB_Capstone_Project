using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SlimUI.ModernMenu{
	public class MainMenu : MonoBehaviour
	{
		public Animator CameraObject;

		public enum Theme {custom1, custom2, custom3};
		[Header("Theme Settings")]
		public Theme theme;
		int themeIndex;
		public FlexibleUIData themeController;

		[Header("Panels")]
		[Tooltip("The UI Panel parenting all sub menus")]
		public GameObject mainCanvas;
		[Tooltip("The UI Panel parenting options menus")]
		public GameObject optionsCanvas;
		[Tooltip("The UI Panel parenting loading")]
		public GameObject loadingCanvas;

		[Header("Menus")]
		[Tooltip("The Menu for when the PLAY button is clicked")]
		public GameObject playMenu;
		[Tooltip("The Menu for when the EXIT button is clicked")]
		public GameObject exitMenu;
		[Tooltip("Optional 4th Menu")]
		public GameObject extrasMenu;

		void Start()
		{
			SetThemeColors();
		}

		void SetThemeColors()
		{
			if(theme == Theme.custom1){
				themeController.currentColor = themeController.custom1.graphic1;
				themeController.textColor = themeController.custom1.text1;
				themeIndex = 0;
			}else if(theme == Theme.custom2){
				themeController.currentColor = themeController.custom2.graphic2;
				themeController.textColor = themeController.custom2.text2;
				themeIndex = 1;
			}else if(theme == Theme.custom3){
				themeController.currentColor = themeController.custom3.graphic3;
				themeController.textColor = themeController.custom3.text3;
				themeIndex = 2;
			}
		}

        public void Reset()
        {
			if (playMenu) playMenu.SetActive(false);
			if (extrasMenu) extrasMenu.SetActive(false);
			if (exitMenu) exitMenu.SetActive(false);
		}

        public void PlayCampaign()
		{
			playMenu.SetActive(true);
			if (extrasMenu) extrasMenu.SetActive(false);
			if (exitMenu) exitMenu.SetActive(false);
		}

		public void NewGame()
		{
			mainCanvas.SetActive(false);
			optionsCanvas.SetActive(false);
			loadingCanvas.SetActive(true);
		}

		public void Position1()
		{
			CameraObject.SetFloat("Animate", 0);
		}

		public void Position2()
		{
			CameraObject.SetFloat("Animate", 1);
		}

		public void AreYouSure()
		{
			if (playMenu) playMenu.SetActive(false);
			if (extrasMenu) extrasMenu.SetActive(false);
			exitMenu.SetActive(true);
		}

		public void ExtrasMenu()
		{
			if (playMenu) playMenu.SetActive(false);
			extrasMenu.SetActive(true);
			if (exitMenu) exitMenu.SetActive(false);
		}

		public void QuitGame()
		{
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}
	}
}