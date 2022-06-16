using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuas4 : MonoBehaviour
{
    [SerializeField] GameObject Belakang;
    [SerializeField] GameObject Tengah;

    void OnTriggerStay(Collider col)
    {
        if(Input.GetKeyDown(KeyCode.E) && col.tag == "Player")
        {
            Belakang.GetComponent<Animator>().SetTrigger("Move");
            Tengah.GetComponent<Animator>().SetTrigger("Move");
        }
    }
}