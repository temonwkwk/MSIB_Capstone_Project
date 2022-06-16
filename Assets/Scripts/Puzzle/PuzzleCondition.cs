using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCondition : MonoBehaviour
{

    public int progressCondition;
    public bool isDeactivated;
    public bool isActivated;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isDeactivated == true)
        {
            if (GameData.instance.progressData >= progressCondition)
            {
                gameObject.SetActive(false);

            }
        }

        if(isActivated == true)
        {
            if (GameData.instance.progressData >= progressCondition)
            {
                gameObject.SetActive(true);

            }
        }
    }
}
