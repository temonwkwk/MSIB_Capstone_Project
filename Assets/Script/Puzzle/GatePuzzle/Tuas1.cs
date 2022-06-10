using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuas1 : MonoBehaviour
{
    [SerializeField] GameObject Depan;
    [SerializeField] GameObject Belakang;

    void OnTriggerStay(Collider col)
    {
        if(Input.GetKeyDown(KeyCode.E) && col.tag == "Player")
        {
            Depan.GetComponent<Animator>().SetTrigger("Move");
            Belakang.GetComponent<Animator>().SetTrigger("Move");
            
        }
    }
}
