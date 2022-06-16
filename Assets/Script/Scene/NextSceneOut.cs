using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneOut : MonoBehaviour
{
    private CharacterController PlayerController;
    public string TargetLocName;  //// Target Lokasi player akan muncul dimana?

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = PlayerManager.instance.transform.GetComponent<CharacterController>();

        if (PlayerPrefs.GetString("SceneOutName") == TargetLocName)
        {
            // Debug.Log("playerIsHere");
            PlayerController.enabled = false;
            PlayerManager.instance.transform.position = transform.position;
            PlayerManager.instance.transform.rotation = transform.rotation;
            PlayerController.enabled = true;
        }
    }

    
}
