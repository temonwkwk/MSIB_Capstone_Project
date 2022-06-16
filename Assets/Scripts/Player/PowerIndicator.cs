using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerIndicator : MonoBehaviour
{
    private AudioSource audio;

    public static PowerIndicator instance;

    public AudioClip[] audioClipArray;

    public int power = 0;
    public int maxPower = 3;
    public GameObject[] ppower;

    void Start()
    {
        audio = GetComponent<AudioSource>();

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
            addPower(1);
            sellectPower(power);
        }

        if (maxPower > 3)
        {
            maxPower = 3;
        }
    }

    public void sellectPower(int value)
    {
        switch (value)
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
        if (power > maxPower)
        {
            power = 0;
        }
        else
        {
            PowerUPSFX("change");
        }
    }

    public void PowerUPSFX(string value)
    {
        switch (value)
        {
            case "change":
                audio.clip = audioClipArray[0];
                audio.Play();
                break;

            case "size":
                audio.clip = audioClipArray[1];
                audio.Play();
                break;

            case "dash":
                audio.clip = audioClipArray[2];
                audio.Play();
                break;
        }
    }
}
