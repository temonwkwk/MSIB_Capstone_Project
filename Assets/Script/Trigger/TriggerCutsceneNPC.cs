using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCutsceneNPC : MonoBehaviour
{

    [SerializeField] private GameObject timelineCutscene1;  //Condition = 0/3
    [SerializeField] private GameObject timelineCutscene2;  //Condition = 3/3

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(GameData.instance.progressData == 0)
            {
                GameData.instance.AddProgress(1);
                timelineCutscene1.SetActive(true);
            }

            if (GameData.instance.progressData == 3)
            {
                timelineCutscene2.SetActive(true);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
