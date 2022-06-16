using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneOut : MonoBehaviour
{
    private CharacterController ccontroller;
    private PlayerController pcontroller;

    public string TargetLocName;  //// Target Lokasi player akan muncul dimana?

    // Start is called before the first frame update
    void Start()
    {
        ccontroller = PlayerManager.instance.transform.GetComponent<CharacterController>();
        pcontroller = PlayerManager.instance.transform.GetComponent<PlayerController>();

        if (PlayerPrefs.GetString("SceneOutName") == TargetLocName)
        {
            // Debug.Log("playerIsHere");
            ccontroller.enabled = false;
            pcontroller.enabled = false;
            PlayerManager.instance.transform.position = transform.position;
            PlayerManager.instance.transform.rotation = transform.rotation;
            ccontroller.enabled = true;
            pcontroller.enabled = true;
        }
    }


}
