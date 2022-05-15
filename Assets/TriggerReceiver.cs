using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReceiver : MonoBehaviour
{

    private Animator animator;
    private bool isPlatformup = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlatformUp()
    {
        animator.SetBool("isPlatformup", true);

        StartCoroutine(PlatformDown());
    }

    public IEnumerator PlatformDown()
    {
        yield return new WaitForSeconds(3);
        animator.SetBool("isPlatformup", false);


    }
}
