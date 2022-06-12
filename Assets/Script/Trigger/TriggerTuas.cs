using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerTuas : MonoBehaviour
{
    [SerializeField]private bool playerIsHere;
    public Animator anim;
    public UnityEvent TriggerEvent;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsHere == true && Input.GetKeyDown(KeyCode.E))
        {
            {
                Debug.Log("Key E is Pressed!");
                TriggeringTuas();
                TriggerEvent.Invoke();
                //gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerIsHere = true;

/*            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Key E is Pressed!");
                TriggeringTuas();
                TriggerEvent.Invoke();
                //gameObject.SetActive(false);
            }*/
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerIsHere = false;
            anim.SetBool("isTriggered", false);

        }

    }

    public void TriggeringTuas()
    {
        anim.SetBool("isTriggered", true);
    }

    public void InvokeTrigger()
    {
        TriggerEvent.Invoke();
    }




}
