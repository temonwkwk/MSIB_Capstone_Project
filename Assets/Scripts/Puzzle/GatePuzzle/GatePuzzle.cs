using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatePuzzle : MonoBehaviour
{
    [SerializeField] GameObject Depan;
    [SerializeField] GameObject Tengah;
    [SerializeField] GameObject Belakang;

    // private void OnTriggerEnter(Collider hit)
    // {
    //     if(hit.gameObject.name == "Tuas 1" && Input.GetKeyDown(KeyCode.E))
    //     {
    //         Depan.GetComponent<Animator>().SetTrigger("Move");
    //         Tengah.GetComponent<Animator>().SetTrigger("Move");
    //     }
    // }
}
