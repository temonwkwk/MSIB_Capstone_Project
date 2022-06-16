using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.Playables;
using Cinemachine;

public class CustomTimelinescript : MonoBehaviour
{

    public GameObject mainCamera;
    public TimelineAsset timeline;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = CameraManager.instance.gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
