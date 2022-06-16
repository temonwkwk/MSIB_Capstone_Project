using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuas2 : MonoBehaviour
{
    [SerializeField] GameObject Tengah;
    [SerializeField] GameObject Belakang;
    [SerializeField] GameObject Terakhir;

    void OnTriggerStay(Collider col)
    {
        if(Input.GetKeyDown(KeyCode.E) && col.tag == "Player")
        {
            Tengah.GetComponent<Animator>().SetTrigger("Move");
            Belakang.GetComponent<Animator>().SetTrigger("Move");
            Terakhir.GetComponent<Animator>().SetTrigger("Move");
        }
    }
}
