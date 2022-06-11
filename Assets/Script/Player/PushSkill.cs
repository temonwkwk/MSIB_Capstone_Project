using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSkill : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerPushObject push;
    PowerIndicator powerCount;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        push = player.GetComponent<PlayerPushObject>();
        powerCount = GetComponent<PowerIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerCount.power == 3)
        {
            push.forceMagnitude = 1;
        }
        else 
        {
            push.forceMagnitude = 0;
        }
    }
}
