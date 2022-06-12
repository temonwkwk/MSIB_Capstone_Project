using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneOut : MonoBehaviour
{

    public string TargetLocName;  //// Target Lokasi player akan muncul dimana?
    public CharacterController Playerctrl;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("SceneOutName") == TargetLocName)
        {
            // Debug.Log("playerIsHere");
            Playerctrl = PlayerManager.instance.transform.GetComponent<CharacterController>();
            //Playerctrl = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
            Playerctrl.enabled = false;
            PlayerManager.instance.transform.position = transform.position;
            PlayerManager.instance.transform.rotation = transform.rotation;
            Playerctrl.enabled = true;
        }
    }

    
}
