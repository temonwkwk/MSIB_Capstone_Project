using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneOut : MonoBehaviour
{

    public string newsceneOutName;
    public CharacterController Playerctrl;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("SceneOutName") == newsceneOutName)
        {
            // Debug.Log("playerIsHere");
            Playerctrl = PlayerManager.instance.transform.GetComponent<CharacterController>();
            Playerctrl.enabled = false;
            PlayerManager.instance.transform.position = transform.position;
            Playerctrl.enabled = true;
        }
    }

    
}
