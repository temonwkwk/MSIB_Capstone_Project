using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneOut : MonoBehaviour
{

    public string newsceneOutName;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("SceneOutName") == newsceneOutName)
        {
            // Debug.Log("playerIsHere");
            PlayerManager.instance.transform.position = gameObject.transform.position;
        }
    }

    
}
