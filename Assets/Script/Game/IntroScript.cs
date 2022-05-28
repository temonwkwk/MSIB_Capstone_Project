using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private int loadSceneByNumber;
#pragma warning restore 649

    private float beginning;

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
        SceneManager.LoadScene(loadSceneByNumber);
    }
}
