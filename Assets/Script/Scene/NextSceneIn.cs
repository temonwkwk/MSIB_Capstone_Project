using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneIn : MonoBehaviour
{

    public string nextSceneName; // Target Scene selanjutnya?
    public string TargetLocName; // Target Lokasi player akan muncul dimana? 

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetString("SceneOutName", TargetLocName);
            SceneManager.LoadSceneAsync(nextSceneName);
        }

    }
}
