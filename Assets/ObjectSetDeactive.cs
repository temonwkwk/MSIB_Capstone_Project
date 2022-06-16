using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSetDeactive : MonoBehaviour
{
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
        /*        if(other.gameObject.CompareTag("player"))
                {
                    other.gameObject.SetActive(false);
                }*/

        PlayerManager.instance.gameObject.SetActive(false);
        StartCoroutine("ReActive");

    }

    IEnumerator ReActive()
    {
        yield return new WaitForSeconds(5);
        PlayerManager.instance.gameObject.SetActive(true);
    }
}
