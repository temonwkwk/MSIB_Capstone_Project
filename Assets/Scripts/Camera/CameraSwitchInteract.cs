using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class CameraSwitchInteract : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Vector3 boxSize;
    [SerializeField] private CinemachineVirtualCamera newCam;

    BoxCollider box;
    Rigidbody rb;

    private void Awake()
    {
        box = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        box.isTrigger = true;
        box.size = boxSize;

        rb.isKinematic = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }

    private void OnTriggerStay(Collider other)
    {
        //enter -> press F -> cameraChanged
        ///if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        ///
        //enter -> cameraChanged
        if (other.gameObject.CompareTag("Player")) 
        {
            if (CameraSwitcher.ActiveCamera != cam)
            {
                CameraSwitcher.SwitchCamera(cam);
                Debug.Log("CameraChanged");
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (CameraSwitcher.ActiveCamera != newCam)
            {
                CameraSwitcher.SwitchCamera(newCam);
                Debug.Log("CameraReturnBack");
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
