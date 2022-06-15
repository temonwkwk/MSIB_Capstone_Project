using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    public bool questItem1;
    public bool questItem2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(questItem1 == true)
        {
            questItem2 = false;

            if(GameData.instance.progressData >= 2 || PowerIndicator.instance.maxPower != 1)
            {
                Destroy(gameObject);
            }
        }
        if (questItem2 == true)
        {
            questItem1 = false;
            if (GameData.instance.progressData >= 3 || PowerIndicator.instance.maxPower != 2)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameData.instance.AddProgress(1);
            PowerIndicator.instance.addMaxPower(1);

            gameObject.SetActive(false);
        }
    }
}
