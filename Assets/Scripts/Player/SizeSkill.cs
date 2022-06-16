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
        player = PlayerManager.instance.gameObject;
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
                anim.Play("Small");
                anim.SetBool("Shrink", true);
                // anim.Play("Idle");
                shrink = true;
                PowerIndicator.instance.PowerUPSFX("size");
            }
            else
            {
                // anim.Play("Growth");
                anim.Play("Big");
                anim.SetBool("Shrink", false);
                shrink = false;
                PowerIndicator.instance.PowerUPSFX("size");
            }
            cooldownFinish = Time.time + cooldownTime;
        }
        if (powerCount.power != 2 && shrink == true)
        {
            // anim.Play("Growth");
            anim.Play("Big");
            anim.SetBool("Shrink", false);
            shrink = false;
        }
    }
}