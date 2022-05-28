using UnityEngine;
using Cinemachine;

public class CameraFreeLookInsert : MonoBehaviour
{
    public GameObject fPlayerTarget;
    public Transform fPlayerTransform;
    //private CinemachineVirtualCamera vcam;
    private CinemachineFreeLook flcam;

    // Use this for initialization
    void Start()
    {
        //vcam = GetComponent<CinemachineVirtualCamera>();
        flcam = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (fPlayerTarget == null)
        {
            fPlayerTarget = GameObject.FindWithTag("Player");
            if (fPlayerTarget != null)
            {
                fPlayerTransform = fPlayerTarget.transform;
                flcam.LookAt = fPlayerTransform;
                flcam.Follow = fPlayerTransform;
            }
        }
    }
}