using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerFallOutBoundary : MonoBehaviour
{

    public CharacterController Playerctrl;
    public GameObject reSpawn;

    // Start is called before the first frame update
    void Start()
    {
        reSpawn = GameObject.FindGameObjectWithTag("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Playerctrl = PlayerManager.instance.transform.GetComponent<CharacterController>();
            //Playerctrl = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
            Playerctrl.enabled = false;
            PlayerManager.instance.transform.position = reSpawn.transform.position;
            PlayerManager.instance.transform.rotation = reSpawn.transform.rotation;
            Playerctrl.enabled = true;
        }

    }
}
