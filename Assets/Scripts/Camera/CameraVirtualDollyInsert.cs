using UnityEngine;
using Cinemachine;

public class CameraVirtualDollyInsert : MonoBehaviour
{
    public GameObject vPlayerTarget;
    public Transform vPlayerTransform;
    private CinemachineVirtualCamera vcam;


    // Use this for initialization
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();

    }

    // Update is called once per frame
    void Update()
    {
        if (vPlayerTarget == null)
        {
            vPlayerTarget = GameObject.FindWithTag("Player");
            if (vPlayerTarget != null)
            {
                vPlayerTransform = vPlayerTarget.transform;
                vcam.LookAt = vPlayerTransform;
                vcam.Follow = vPlayerTransform;

            }
        }
    }
}
