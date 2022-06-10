using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTuas : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            TriggeringTuas();
        }
    }

    public void TriggeringTuas()
    {
        anim.SetBool("isTriggered", true);
    }


}
