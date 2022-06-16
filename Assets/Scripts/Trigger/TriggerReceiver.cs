using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReceiver : MonoBehaviour
{
    [Header("if Using Animator")]
    [SerializeField] private string parameterBoolName;  //animator parameter name
    [SerializeField] private float waitFor;             // delay trigger
    private Animator animator;

    [Header("if Using Script")]
    [SerializeField] private float transformSpeed;
    [SerializeField] private float transformlength;
    [SerializeField] private float startPos;

     [Header("bool Trigger")]
    public bool trigger1;           //trigger - Stay  atau Looping **sesuai animasi
    public bool trigger2;           //trigger - Return/Loop after "waitFor" second
  //  public bool trigger3;           //trigger - Start Looping 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        trigger1 = false;
        trigger2 = false;
     //   trigger3 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger1 == true)
        {
            TriggerOn();
        }

        if (trigger2 == true)
        {
            TriggerOn();
            StartCoroutine(ReturnTrigger());
        }
/*        if (trigger3 == true)
        {
             TriggerLoop();
            TriggerOn();

        }*/
    }

    public void TriggerOn()
    {
        animator.SetBool(parameterBoolName, true);
        //StartCoroutine(ReturnTrigger());
    }
    public void TriggerOff()
    {
        animator.SetBool(parameterBoolName, false);
        //StartCoroutine(ReturnTrigger());

    }

    public IEnumerator ReturnTrigger()
    {
        yield return new WaitForSeconds(waitFor);
        TriggerOff();
        trigger2 = false;
    }

/*    public void TriggerLoop()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, startPos + Mathf.PingPong(transformSpeed * Time.time, transformlength));
    }*/
}
