using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    [SerializeField] private VideoPlayer videoPlayer;
    private float beginning;

    [Header("Loaded Scene")]
    [Tooltip("The name of the scene in the build settings that will load")]
    public string sceneName = "";    

    void Start()
    {
        StartCoroutine(waitawake());
    }

    IEnumerator waitawake()
    {
        beginning = Time.time;
        while (Time.time - beginning < videoPlayer.length)
        {
            yield return null;
        }
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
