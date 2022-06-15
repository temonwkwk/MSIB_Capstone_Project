using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_canvasMngr : MonoBehaviour
{
    public static temp_canvasMngr instance;

    // Start is called before the first frame update
    void Awake()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
