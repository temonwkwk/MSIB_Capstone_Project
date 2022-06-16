using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerIndicator : MonoBehaviour
{

    public static PowerIndicator instance;


    public int power = 0;
    public int maxPower = 3;
    public GameObject[] ppower;

    void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
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

        if(maxPower > 3)
        {
            maxPower = 3;
        }

        switch (power)
        {
            case 0:
                ppower[0].SetActive(false);
                ppower[1].SetActive(false);
                ppower[2].SetActive(false);
                break;

            case 1:
                ppower[0].SetActive(true);
                ppower[1].SetActive(false);
                ppower[2].SetActive(false);
                break;

            case 2:
                ppower[0].SetActive(false);
                ppower[1].SetActive(true);
                ppower[2].SetActive(false);
                break;

            case 3:
                ppower[0].SetActive(false);
                ppower[1].SetActive(false);
                ppower[2].SetActive(true);
                break;
        }
    }

    public void addMaxPower(int addmaxPower)
    {
        maxPower += addmaxPower;
    }

    public void addPower(int addpower)
    {
        power += addpower;
    }
}