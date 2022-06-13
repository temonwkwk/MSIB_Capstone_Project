using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : MonoBehaviour
{
    [SerializeField] GameObject player;
    PlayerController moveScript;
    PowerIndicator powerCount;
    public float dashSpeed;
    public float dashTime;
    public float cooldownTime = 1;
    private float cooldownFinish = 0;
    void Start()
    {
        player = PlayerManager.instance.gameObject;
        moveScript = player.GetComponent<PlayerController>();
        powerCount = GetComponent<PowerIndicator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && powerCount.power == 1 && Time.time > cooldownFinish)
        {
            StartCoroutine(Dash());
            cooldownFinish = Time.time + cooldownTime;
            // Debug.Log("Dash");
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while(Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(moveScript.move * dashSpeed * Time.deltaTime );
            yield return null;
            Debug.Log("Dash");
        }
    }
}
