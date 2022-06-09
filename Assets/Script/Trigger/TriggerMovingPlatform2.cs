using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMovingPlatform2 : MonoBehaviour
{

    // Moving Platform 2 = Bergerak ketika player trigger 
    // automatic = false;

    public MovingPlatform platform;

    private void OnTriggerEnter(Collider other)
    {
        platform.NextPlatform();
    }

    public void OnTriggerExit(Collider other)
    {
        platform.ReturnPlatform();
    }
}
