using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBGM : MonoBehaviour
{

    private void Awake()
    {
        Destroy(GameObject.Find("BGM"));
    }
}
