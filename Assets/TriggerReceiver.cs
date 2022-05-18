using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReceiver : MonoBehaviour
{

    [SerializeField] private string parameterBoolName;
    [SerializeField] private float waitFor;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerOn()
    {
        animator.SetBool(parameterBoolName, true);

        StartCoroutine(ReturnTrigger());
    }

    public IEnumerator ReturnTrigger()
    {
        yield return new WaitForSeconds(waitFor);
        animator.SetBool(parameterBoolName, false);
    }
}
