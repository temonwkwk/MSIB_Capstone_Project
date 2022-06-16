using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    public GameObject confirmPanel;

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
            confirmPanel.SetActive(true);
            //StartCoroutine("offPanel");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            confirmPanel.SetActive(false);
            //StartCoroutine("offPanel");
        }
    }

    /*    public IEnumerator offPanel()
        {
            yield return new WaitForSeconds(3);
            confirmPanel.SetActive(false);

        }*/
}
