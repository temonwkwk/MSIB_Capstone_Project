using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NextSceneIn : MonoBehaviour
{
	private CharacterController ccontroller;
	private PlayerController pcontroller;

	[Header("Loaded Scene")]
	public string nextSceneName; // Target Scene selanjutnya?
	public string TargetLocName; // Target Lokasi player akan muncul dimana? 

	[Header("LOADING SCREEN")]
	public GameObject loadingCanvas;
	public Slider loadBar;
	public TMP_Text finishedLoadingText;
	public bool useLoading;

    void Start()
    {
		ccontroller = PlayerManager.instance.transform.GetComponent<CharacterController>();
		pcontroller = PlayerManager.instance.transform.GetComponent<PlayerController>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
			PlayerPrefs.SetString("SceneOutName", TargetLocName);
			if (useLoading)
            {
				ccontroller.enabled = false;
				pcontroller.enabled = false;
				loadingCanvas.SetActive(true);
				StartCoroutine(LoadAsynchronously(nextSceneName));
            }
            else
            {
				SceneManager.LoadSceneAsync(nextSceneName);
			}
		}

    }

	IEnumerator LoadAsynchronously(string nextSceneName)
	{ // scene name is just the name of the current scene being loaded
		AsyncOperation operation = SceneManager.LoadSceneAsync(nextSceneName);
		operation.allowSceneActivation = false;

		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			loadBar.value = progress;

			if (operation.progress >= 0.9f)
			{
				finishedLoadingText.gameObject.SetActive(true);

				if (Input.GetKeyDown("space"))
				{
					operation.allowSceneActivation = true;
				}
			}

			yield return null;
		}
	}
}
