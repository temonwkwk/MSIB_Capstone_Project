using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScript : MonoBehaviour
{

	[Header("Loaded Scene")]
	[Tooltip("The name of the scene in the build settings that will load")]
	public string sceneName = "";

	[Header("LOADING SCREEN")]
	public Slider loadBar;
	public TMP_Text finishedLoadingText;

    void Awake()
    {
		StartCoroutine(LoadAsynchronously(sceneName));
	}

    IEnumerator LoadAsynchronously(string sceneName)
	{ // scene name is just the name of the current scene being loaded
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
		operation.allowSceneActivation = false;

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			loadBar.value = progress;

			if (operation.progress >= 0.9f)
			{
				finishedLoadingText.gameObject.SetActive(true);

				if (Input.anyKeyDown)
				{
					operation.allowSceneActivation = true;
				}
			}

			yield return null;
		}
	}
}
