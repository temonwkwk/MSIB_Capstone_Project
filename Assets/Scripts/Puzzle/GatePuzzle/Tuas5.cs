using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuas5 : MonoBehaviour
{
    [SerializeField] GameObject Depan;
    [SerializeField] GameObject Tengah;
    [SerializeField] GameObject Belakang;
    [SerializeField] GameObject Terakhir;

    void OnTriggerStay(Collider col)
    {
        if(Input.GetKeyDown(KeyCode.E) && col.tag == "Player")
        {
            Depan.GetComponent<Animator>().SetTrigger("Reset");
            Tengah.GetComponent<Animator>().SetTrigger("Reset");
            Belakang.GetComponent<Animator>().SetTrigger("Reset");
            Terakhir.GetComponent<Animator>().SetTrigger("Reset");
        }
    }
}
