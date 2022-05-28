using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeSkill : MonoBehaviour
{
    [SerializeField] GameObject player;
    Animator anim;
    PowerIndicator powerCount;
    bool shrink;
    public float cooldownTime = 2;
    private float cooldownFinish = 0;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        powerCount = GetComponent<PowerIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) && powerCount.power == 2 && Time.time > cooldownFinish)
        {
            if(shrink == false)
            {
                anim.SetBool("Shrink", true);
                shrink = true;
            }
            else
            {
                anim.SetBool("Shrink", false);
                shrink = false; 
            }
            cooldownFinish = Time.time + cooldownTime;
        }
        if (powerCount.power != 2 && shrink == true)
        {
            anim.SetBool("Shrink", false);
            shrink = false;
        }
    }
}
