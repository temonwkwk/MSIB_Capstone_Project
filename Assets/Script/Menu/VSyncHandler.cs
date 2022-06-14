using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VSyncHandler : MonoBehaviour
{
    public void SetVSync(int value)
    {
        QualitySettings.vSyncCount = value;
    }
}
