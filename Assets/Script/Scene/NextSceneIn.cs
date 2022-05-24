using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneIn : MonoBehaviour
{

    public string nextSceneName;
    public string sceneOutName;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetString("SceneOutName", sceneOutName);
        SceneManager.LoadSceneAsync(nextSceneName);
    }
}
