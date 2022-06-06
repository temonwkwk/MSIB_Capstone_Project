using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPush : MonoBehaviour
{

    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim = other.GetComponent<Animator>();
            anim.SetBool("isPushing", true);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim = other.GetComponent<Animator>();
            anim.SetBool("isPushing", false);
        }

    }
}
