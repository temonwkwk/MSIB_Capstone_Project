using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerIndicator : MonoBehaviour
{
    public float power = 0;
    public float maxPower = 3;

    void Start()
    {
    }

    void Update()
    {
        //Input Power
        if (Input.GetKeyDown(KeyCode.Q))
        {
            power++;
        }

        //Biar Power Balik ke Awal
        if (power > maxPower)
        {
            power = 0;
        }
    }
}
