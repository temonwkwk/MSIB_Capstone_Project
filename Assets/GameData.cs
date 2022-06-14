using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class GameData : MonoBehaviour
{

    public static GameData instance;

    public int progressData;
    public int targetCondition;
    public bool Condition = false;

    public UnityEvent ConditionEvent;
    bool isComplete = false;



    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (progressData == targetCondition)
        {
            Condition = true;
        }


        if (!isComplete && Condition == true)
        {
            ConditionEvent.Invoke();
            Debug.Log("Mission Complete!");
            isComplete = true;

        }
    }

    public void AddProgress(int progress)
    {
        if (progressData <= targetCondition)
        {
            progressData += progress;
        }
    }


}
