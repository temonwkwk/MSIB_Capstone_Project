using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

namespace SlimUI.ModernMenu{
	public class MainMenu : MonoBehaviour {
		public Animator CameraObject;

		[Header("Loaded Scene")]
		[Tooltip("The name of the scene in the build settings that will load")]
		public string sceneName = ""; 

		public enum Theme {custom1, custom2, custom3};
		[Header("Theme Settings")]
		public Theme theme;
		int themeIndex;
		public FlexibleUIData themeController;

		[Header("Panels")]
		[Tooltip("The UI Panel parenting all sub menus")]
		public GameObject mainCanvas;
		[Tooltip("The UI Panel parenting all options menus")]
		public GameObject optionsCanvas;
		[Tooltip("The UI Panel that holds the CONTROLS window tab")]
		public GameObject PanelControls;
		[Tooltip("The UI Panel that holds the VIDEO window tab")]
		public GameObject PanelVideo;
		[Tooltip("The UI Panel that holds the GAME window tab")]
		public GameObject PanelGame;

		// campaign button sub menu
		[Header("Menus")]
		[Tooltip("The Menu for when the MAIN menu buttons")]
		public GameObject mainMenu;
		[Tooltip("The Menu for when the PLAY button is clicked")]
		public GameObject playMenu;
		[Tooltip("The Menu for when the EXIT button is clicked")]
		public GameObject exitMenu;
		[Tooltip("Optional 4th Menu")]
		public GameObject extrasMenu;

		// highlights
		[Header("Highlight Effects")]
		[Tooltip("Highlight Image for when GAME Tab is selected in Settings")]
		public GameObject lineGame;
		[Tooltip("Highlight Image for when VIDEO Tab is selected in Settings")]
		public GameObject lineVideo;
		[Tooltip("Highlight Image for when CONTROLS Tab is selected in Settings")]
		public GameObject lineControls;

		[Header("LOADING SCREEN")]
		public GameObject loadingMenu;
		public Slider loadBar;
		public TMP_Text finishedLoadingText;

		private float beginning;

		void Start(){
			mainMenu.SetActive(true);

			SetThemeColors();
		}

		void SetThemeColors(){
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

        public void PlayCampaign(){
			playMenu.SetActive(true);
			if (extrasMenu) extrasMenu.SetActive(false);
			if (exitMenu) exitMenu.SetActive(false);
		}

		public void NewGame(){
			if(sceneName != ""){
				StartCoroutine(LoadAsynchronously(sceneName));
				//SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
			}
		}

		public void ReturnMenu()
		{
			Reset();
			if (optionsCanvas) StartCoroutine(Position1());
		}

		public void OptionsMenu()
		{
			StartCoroutine(Position2());
		}

		IEnumerator Position1()
		{
			mainCanvas.SetActive(true);
			CameraObject.SetFloat("Animate", 0);
			beginning = Time.time;
			while (Time.time - beginning < CameraObject.GetCurrentAnimatorStateInfo(0).length)
			{
				yield return null;
			}
			optionsCanvas.SetActive(false);
		}

		IEnumerator Position2(){
			optionsCanvas.SetActive(true);
			CameraObject.SetFloat("Animate", 1);
			beginning = Time.time;
			while (Time.time - beginning < CameraObject.GetCurrentAnimatorStateInfo(0).length)
			{
				yield return null;
			}
			Reset();
			mainCanvas.SetActive(false);
		}

		void DisablePanels(){
			PanelControls.SetActive(false);
			PanelVideo.SetActive(false);
			PanelGame.SetActive(false);

			lineGame.SetActive(false);
			lineControls.SetActive(false);
			lineVideo.SetActive(false);
		}

		public void GamePanel(){
			DisablePanels();
			PanelGame.SetActive(true);
			lineGame.SetActive(true);
		}

		public void VideoPanel(){
			DisablePanels();
			PanelVideo.SetActive(true);
			lineVideo.SetActive(true);
		}

		public void ControlsPanel(){
			DisablePanels();
			PanelControls.SetActive(true);
			lineControls.SetActive(true);
		}

		// Are You Sure - Quit Panel Pop Up
		public void AreYouSure(){
			if (playMenu) playMenu.SetActive(false);
			if (extrasMenu) extrasMenu.SetActive(false);
			exitMenu.SetActive(true);
		}

		public void ExtrasMenu(){
			if (playMenu) playMenu.SetActive(false);
			extrasMenu.SetActive(true);
			if (exitMenu) exitMenu.SetActive(false);
		}

		public void QuitGame(){
			#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit();
			#endif
		}

		IEnumerator LoadAsynchronously(string sceneName){ // scene name is just the name of the current scene being loaded
			AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
			operation.allowSceneActivation = false;
			mainCanvas.SetActive(false);
			loadingMenu.SetActive(true);

			while (!operation.isDone){
				float progress = Mathf.Clamp01(operation.progress / .9f);
				loadBar.value = progress;

				if(operation.progress >= 0.9f){
					finishedLoadingText.gameObject.SetActive(true);

					if(Input.anyKeyDown){
						operation.allowSceneActivation = true;
					}
				}
				
				yield return null;
			}
		}
	}
}