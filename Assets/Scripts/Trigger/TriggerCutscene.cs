using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutscene : MonoBehaviour
{

    [SerializeField] private GameObject timelineCutscene;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            timelineCutscene.SetActive(true);
        }
    }
}
