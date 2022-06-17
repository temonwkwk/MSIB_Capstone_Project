using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveOnCutscene : MonoBehaviour
{
    private PlayerController pcontroller;

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
              if(other.gameObject.CompareTag("player"))
                {
                    other.gameObject.SetActive(false);
                }

        //pcontroller.enabled = false;

        StartCoroutine("ReActive");

    }

    IEnumerator ReActive()
    {
        yield return new WaitForSeconds(15);
        PlayerManager.instance.gameObject.SetActive(true);

        //pcontroller.enabled = true;
    }
}
