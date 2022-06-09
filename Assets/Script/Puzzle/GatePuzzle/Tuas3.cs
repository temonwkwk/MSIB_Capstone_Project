using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuas3 : MonoBehaviour
{
    [SerializeField] GameObject Belakang;
    [SerializeField] GameObject Terakhir;

    void OnTriggerStay(Collider col)
    {
        if(Input.GetKeyDown(KeyCode.E) && col.tag == "Player")
        {
            Belakang.GetComponent<Animator>().SetTrigger("Move");
            Terakhir.GetComponent<Animator>().SetTrigger("Move");
        }
    }
}
