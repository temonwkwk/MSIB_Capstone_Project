using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerIndicator : MonoBehaviour
{
    public float power;
    public float maxPower;
    // Start is called before the first frame update
    void Start()
    {
        power = 0;
        maxPower = 2;
    }

    // Update is called once per frame
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
