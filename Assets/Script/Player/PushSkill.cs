using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSkill : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerController push;
    PowerIndicator powerCount;
    bool active;
    // Start is called before the first frame update
    void Start()
    {
        player = PlayerManager.instance.gameObject;
        push = player.GetComponent<PlayerController>();
        powerCount = GetComponent<PowerIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (powerCount.power == 3)
        {
            push.pushForce = 2;
        }
        else 
        {
            push.pushForce = 0;
        }
    }
}
