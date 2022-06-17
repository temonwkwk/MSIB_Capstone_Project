using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ExtrasMuteVolume : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        audioMixer.SetFloat("BGMVol", -80f);
        audioMixer.SetFloat("SFXVol", -80f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
